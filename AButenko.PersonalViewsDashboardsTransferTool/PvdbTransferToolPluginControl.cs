using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ServiceModel;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using AButenko.PersonalViewsDashboardsTransferTool.DataContract;

namespace AButenko.PersonalViewsDashboardsTransferTool
{
    public partial class PvdbTransferToolPluginControl : MultipleConnectionsPluginControlBase, IStatusBarMessenger
    {
        #region CTOR

        public PvdbTransferToolPluginControl()
        {
            InitializeComponent();
        }

        #endregion CTOR

        #region Events

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        #endregion Events

        #region UI Handlers - Boring Stuff

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            if (Service != null)
            {
                SetSourceConnected();
            }

            ddViewsMigrationType.SelectedIndex = 0;
            ddPersonalChartsMigrationType.SelectedIndex = 0;
            ddPersonalDashboardMigrationType.SelectedIndex = 0;
        }

        private void SetSourceConnected()
        {
            gbSourceInstance.Text = $"Source Instance - {ConnectionDetail.ConnectionName}";
            lblSourceConnectionState.Text = "Connected";
            lblSourceConnectionState.ForeColor = Color.Green;

            loadUsersAndTeamsToolStripMenuItem.Enabled = Service != null && AdditionalConnectionDetails.Count > 0;
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (actionName == string.Empty)
            {
                SetSourceConnected();
            }
        }

        private void btnConnectToTarget_Click(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            gbDestinationInstance.Text = $"Destination Instance - {AdditionalConnectionDetails[AdditionalConnectionDetails.Count - 1].ConnectionName}";
            lblDestinationConnectionState.Text = "Connected";
            lblDestinationConnectionState.ForeColor = Color.Green;

            loadUsersAndTeamsToolStripMenuItem.Enabled = Service != null && AdditionalConnectionDetails.Count > 0;
        }

        private void btnConnectToSource_Click(object sender, EventArgs e)
        {
            RaiseRequestConnectionEvent(new RequestConnectionEventArgs()
            {
                ActionName = string.Empty,
                Control = this
            });
        }

        private void btnLoadUsers_Click(object sender, EventArgs e)
        {
            HideNotification();

            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading Users and Teams",
                Work = RetrieveUsers,
                PostWorkCallBack = OnUsersRetrieved
            });
        }

        private void loadPrivateViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading Personal Views",
                Work = RetrievePrivateViews,
                PostWorkCallBack = OnPrivateViewsRetrieved
            });
        }

        private void loadPrivateDashboardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading Personal Dashboards",
                Work = RetrievePrivateDashboards,
                PostWorkCallBack = OnPrivateDashboardsRetrieved
            });
        }

        private void menuItemLoadPersonalCharts_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Loading Personal Charts",
                Work = RetrievePersonalCharts,
                PostWorkCallBack = OnPersonalChartsRetrieved
            });
        }

        private void migratePrivateViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Migrating Personal Views",
                Work = MigratePrivateViews,
                AsyncArgument = (MigrationType)ddViewsMigrationType.SelectedIndex,
                PostWorkCallBack = OnMigratePrivateViewsCompleted 
            });
        }

        private void menuItemMigratePersonalCharts_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Migrating Personal Charts",
                Work = MigratePersonalCharts,
                AsyncArgument = (MigrationType)ddPersonalChartsMigrationType.SelectedIndex,
                PostWorkCallBack = OnMigratePersonalChartsCompleted
            });
        }

        private void migratePrivateDashboardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Migrating Personal Dashboards",
                Work = MigratePersonalDashboards,
                AsyncArgument = (MigrationType)ddPersonalDashboardMigrationType.SelectedIndex,
                PostWorkCallBack = OnMigratePersonalDashboardsCompleted
            });
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            mappings.ForEach(m => m.IsMigrate = cbSelectAll.Checked);
            dgMapping.EndEdit();
            dgMapping.Refresh();
        }

        #endregion UI Handlers - Boring Stuff

        #region Runtime Variables

        private List<Record> sourceRecords = new List<Record>();
        private List<Record> destRecords = new List<Record>();
        private List<RecordMapping> mappings = new List<RecordMapping>();
        private List<PersonalView> personalViews = new List<PersonalView>();
        private List<PersonalChart> personalCharts = new List<PersonalChart>();
        private List<PersonalDashboard> personalDashboards = new List<PersonalDashboard>();

        #endregion Runtime Variables

        #region Data Retrieval

        private List<Entity> RetrieveRecords(IOrganizationService service)
        {
            var usersQuery = new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet("fullname"),
                PageInfo = new PagingInfo()
                {
                    Count = 5000,
                    PageNumber = 1
                }
            };

            usersQuery.Criteria.AddCondition("domainname", ConditionOperator.NotNull);
            usersQuery.Criteria.AddCondition("domainname", ConditionOperator.NotEqual, string.Empty);
            usersQuery.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);
            usersQuery.AddOrder("fullname", OrderType.Ascending);

            var allRecords = service.RetrieveAll(usersQuery);

            var teamsQuery = new QueryExpression("team")
            {
                ColumnSet = new ColumnSet("name"),
                PageInfo = new PagingInfo()
                {
                    Count = 5000,
                    PageNumber = 1
                }
            };

            teamsQuery.Criteria.AddCondition("teamtype", ConditionOperator.Equal, 0);
            teamsQuery.AddOrder("name", OrderType.Ascending);

            allRecords.AddRange(service.RetrieveAll(teamsQuery));

            return allRecords;
        }

        private List<Entity> RetrieveSharings(IOrganizationService service, EntityReference record)
        {
            var sharingQuery = new QueryExpression("principalobjectaccess")
            {
                ColumnSet = new ColumnSet("accessrightsmask", "principalid", "principaltypecode")
            };
            sharingQuery.Criteria.AddCondition("objectid", ConditionOperator.Equal, record.Id);
            sharingQuery.Criteria.AddCondition("objecttypecode", ConditionOperator.Equal, record.LogicalName);

            return service.RetrieveAll(sharingQuery);
        }

        #endregion Data Retrieval

        private void RetrieveUsers(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var sr = RetrieveRecords(Service);
            var dr = RetrieveRecords(AdditionalConnectionDetails[AdditionalConnectionDetails.Count - 1]
                .GetCrmServiceClient(true));

            args.Result = new object[] { sr, dr };
        }

        private void OnUsersRetrieved(RunWorkerCompletedEventArgs args)
        {
            var results = (object[]) args.Result;

            sourceRecords = ((List<Entity>) results[0]).Select(r => new Record(r)).ToList();
            destRecords = ((List<Entity>)results[1]).Select(r => new Record(r)).ToList();

            mappings = sourceRecords.Select(r => new RecordMapping()
            {
                SourceRecord = r.Id,
                DestinationRecord = destRecords.FirstOrDefault(d => d.EntityType == r.EntityType && d.DisplayName == r.DisplayName)?.Id,
                IsMigrate = destRecords.FirstOrDefault(d => d.EntityType == r.EntityType && d.DisplayName == r.DisplayName) != null,
                EntityType = r.EntityType
            }).ToList();

            sourceRecordDataGridViewTextBoxColumn.ValueType = typeof(Guid);
            sourceRecordDataGridViewTextBoxColumn.DisplayMember = "DisplayName";
            sourceRecordDataGridViewTextBoxColumn.ValueMember = "Id";
            sourceRecordDataGridViewTextBoxColumn.DataSource = sourceRecords;

            destinationRecordDataGridViewTextBoxColumn.ValueType = typeof(Guid?);
            destinationRecordDataGridViewTextBoxColumn.DisplayMember = "DisplayName";
            destinationRecordDataGridViewTextBoxColumn.ValueMember = "Id";
            destinationRecordDataGridViewTextBoxColumn.DataSource = destRecords;

            dgMapping.DataSource = mappings;
        }

        private void RetrievePrivateViews(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var pv = new List<Entity>();

            mappings.Where(m => m.IsMigrate && m.EntityType == "systemuser").Select(m => m.SourceRecord).ToList().ForEach(
                userId =>
                {
                    ((OrganizationServiceProxy) Service).CallerId = userId;

                    var viewsQuery = new QueryExpression("userquery")
                    {
                        ColumnSet = new ColumnSet(true),
                        PageInfo = new PagingInfo()
                        {
                            PageNumber = 1,
                            Count = 5000
                        }
                    };
                    viewsQuery.Criteria.AddCondition("ownerid", ConditionOperator.Equal, userId);
                    viewsQuery.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                    viewsQuery.Criteria.AddCondition("querytype", ConditionOperator.Equal, 0);

                    try
                    {
                        pv.AddRange(Service.RetrieveAll(viewsQuery));
                    }
                    catch (FaultException<OrganizationServiceFault> e)
                    {
                        if (!e.Message.Contains("no roles are assigned to user") &&
                            !e.Message.Contains("is missing prvReadUserQuery privilege"))
                        {
                            throw;
                        }
                    }
                });

            args.Result = pv;
        }

        private void OnPrivateViewsRetrieved(RunWorkerCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                ShowErrorNotification($"Can't receive list of personal views - {args.Error.Message}", new Uri($"https://google.com/search?q={Uri.EscapeDataString(args.Error.Message)}"));
                return;
            }

            personalViews = ((List<Entity>) args.Result).Select(r => new PersonalView(r)).ToList();

            tvPrivateViews.Nodes.Clear();

            string currentUserName = null;
            string currentEntityName = null;
            TreeNode currentUserNode = null;
            TreeNode currentEntityTypeNode = null;

            foreach (var pv in personalViews)
            {
                if (pv.Owner != currentUserName)
                {
                    currentUserName = pv.Owner;
                    currentUserNode = tvPrivateViews.Nodes.Add("Owner", currentUserName);
                    currentUserNode.Tag = pv.OwnerId;
                    currentUserNode.Checked = true;
                    currentEntityName = null;
                }

                if (pv.EntityTypeName != currentEntityName)
                {
                    currentEntityName = pv.EntityTypeName;
                    currentEntityTypeNode =
                        currentUserNode.Nodes.Add("EntityType", currentEntityName);
                    currentEntityTypeNode.Tag = pv.EntityTypeName;
                    currentEntityTypeNode.Checked = true;
                }

                var viewNode = currentEntityTypeNode.Nodes.Add("Record", pv.Name);
                viewNode.Tag = pv.RecordId;
                viewNode.Checked = true;
            }
        }

        private void OnMigratePrivateViewsCompleted(RunWorkerCompletedEventArgs args)
        {
            if (args.Error == null)
            {
                return;
            }

            ShowErrorNotification($"Can't migrate personal views - {args.Error.Message}", new Uri($"https://google.com/search?q={Uri.EscapeDataString(args.Error.Message)}"));
        }

        private void RetrievePersonalCharts(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var pc = new List<Entity>();

            mappings.Where(m => m.IsMigrate && m.EntityType == "systemuser").Select(m => m.SourceRecord).ToList().ForEach(
                userId =>
                {
                    ((OrganizationServiceProxy)Service).CallerId = userId;

                    var chartsQuery = new QueryExpression("userqueryvisualization")
                    {
                        ColumnSet = new ColumnSet(true),
                        PageInfo = new PagingInfo()
                        {
                            PageNumber = 1,
                            Count = 5000
                        }
                    };
                    chartsQuery.Criteria.AddCondition("ownerid", ConditionOperator.Equal, userId);
                    chartsQuery.AddOrder("primaryentitytypecode", OrderType.Ascending);
                    chartsQuery.AddOrder("name", OrderType.Ascending);


                    try
                    {
                        pc.AddRange(Service.RetrieveAll(chartsQuery));
                    }
                    catch (FaultException<OrganizationServiceFault> e)
                    {
                        if (!e.Message.Contains("no roles are assigned to user") &&
                            !e.Message.Contains("is missing prvReadUserQueryVisualizations privilege"))
                        {
                            throw;
                        }
                    }
                });

            args.Result = pc;
        }

        private void OnPersonalChartsRetrieved(RunWorkerCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                ShowErrorNotification($"Can't receive list of personal charts - {args.Error.Message}", new Uri($"https://google.com/search?q={Uri.EscapeDataString(args.Error.Message)}"));
                return;
            }

            personalCharts = ((List<Entity>)args.Result).Select(r => new PersonalChart(r)).ToList();

            tvPersonalCharts.Nodes.Clear();

            string currentUserName = null;
            string currentEntityName = null;
            TreeNode currentUserNode = null;
            TreeNode currentEntityTypeNode = null;

            foreach (var pc in personalCharts)
            {
                if (pc.Owner != currentUserName)
                {
                    currentUserName = pc.Owner;
                    currentUserNode = tvPersonalCharts.Nodes.Add("Owner", currentUserName);
                    currentUserNode.Tag = pc.OwnerId;
                    currentUserNode.Checked = true;
                }

                if (pc.EntityTypeName != currentEntityName)
                {
                    currentEntityName = pc.EntityTypeName;
                    currentEntityTypeNode =
                        currentUserNode.Nodes.Add("EntityType", currentEntityName);
                    currentEntityTypeNode.Tag = pc.EntityTypeName;
                    currentEntityTypeNode.Checked = true;
                }

                var viewNode = currentEntityTypeNode.Nodes.Add("Record", pc.Name);
                viewNode.Tag = pc.RecordId;
                viewNode.Checked = true;
            }
        }

        private void OnMigratePersonalChartsCompleted(RunWorkerCompletedEventArgs args)
        {
            if (args.Error == null)
            {
                return;
            }

            ShowErrorNotification($"Can't migrate personal charts - {args.Error.Message}", new Uri($"https://google.com/search?q={Uri.EscapeDataString(args.Error.Message)}"));
        }

        private void RetrievePrivateDashboards(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var pd = new List<Entity>();

            mappings.Where(m => m.IsMigrate && m.EntityType == "systemuser").Select(m => m.SourceRecord).ToList().ForEach(
                userId =>
                {
                    ((OrganizationServiceProxy)Service).CallerId = userId;

                    var dashboardsQuery = new QueryExpression("userform")
                    {
                        ColumnSet = new ColumnSet(true),
                        PageInfo = new PagingInfo()
                        {
                            PageNumber = 1,
                            Count = 5000
                        }
                    };
                    dashboardsQuery.Criteria.AddCondition("ownerid", ConditionOperator.Equal, userId);
                    dashboardsQuery.Criteria.AddCondition("type", ConditionOperator.Equal, 0);
                    dashboardsQuery.AddOrder("name", OrderType.Ascending);

                    try
                    {
                        pd.AddRange(Service.RetrieveAll(dashboardsQuery));
                    }
                    catch (FaultException<OrganizationServiceFault> e)
                    {
                        if (!e.Message.Contains("no roles are assigned to user") &&
                            !e.Message.Contains("is missing prvReadUserForm privilege"))
                        {
                            throw;
                        }
                    }
                });

            args.Result = pd;
        }

        private void OnPrivateDashboardsRetrieved(RunWorkerCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                ShowErrorNotification($"Can't receive list of personal dashboards - {args.Error.Message}", new Uri($"https://google.com/search?q={Uri.EscapeDataString(args.Error.Message)}"));
                return;
            }

            personalDashboards = ((List<Entity>)args.Result).Select(r => new PersonalDashboard(r)).ToList();

            tvPersonalCharts.Nodes.Clear();

            string currentUserName = null;
            TreeNode currentUserNode = null;

            foreach (var pd in personalDashboards)
            {
                if (pd.Owner != currentUserName)
                {
                    currentUserName = pd.Owner;
                    currentUserNode = tvPersonalDashboards.Nodes.Add("Owner", currentUserName);
                    currentUserNode.Tag = pd.OwnerId;
                    currentUserNode.Checked = true;
                }

                var dbNode = currentUserNode.Nodes.Add("Record", pd.Name);
                dbNode.Tag = pd.RecordId;
                dbNode.Checked = true;
            }
        }

        private void OnMigratePersonalDashboardsCompleted(RunWorkerCompletedEventArgs args)
        {
            if (args.Error == null)
            {
                return;
            }

            ShowErrorNotification($"Can't migrate personal dashboards - {args.Error.Message}", new Uri($"https://google.com/search?q={Uri.EscapeDataString(args.Error.Message)}"));
        }

        private void MigratePrivateViews(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var destinationInstance = AdditionalConnectionDetails[AdditionalConnectionDetails.Count - 1]
                .GetCrmServiceClient(true);

            var selectedViews = personalViews.Where(r => r.IsSelected).ToList();

            var totalViews = selectedViews.Count;

            if (totalViews == 0)
            {
                return;
            }

            var currentView = 0;

            selectedViews.ForEach(view =>
            {
                currentView++;

                var currentPersentage = 100 * currentView / totalViews;

                SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(currentPersentage, 
                    $"Importing {view.Owner} - {view.Name}, {currentPersentage}% completed"));

                var sourceOwnerId = view.Record.GetAttributeValue<EntityReference>("ownerid").Id;
                var destinationOwnerId =
                    mappings.FirstOrDefault(t => t.SourceRecord == sourceOwnerId)?.DestinationRecord;

                if (!destinationOwnerId.HasValue)
                {
                    return;
                }

                ((OrganizationServiceProxy) Service).CallerId = sourceOwnerId;

                destinationInstance.CallerId = destinationOwnerId.Value;

                var viewCopy = view.Record.Copy("columnsetxml", "conditionalformatting", "description", "fetchxml",
                    "layoutxml", "name", "querytype", "returnedtypecode", "statecode", "statuscode", "userqueryid");

                viewCopy["ownerid"] = new EntityReference("systemuser", destinationOwnerId.Value);

                destinationInstance.Upsert(viewCopy);

                if ((MigrationType) args.Argument == MigrationType.ViewAndShares)
                {
                    var sharings = RetrieveSharings(Service, view.Record.ToEntityReference());

                    foreach (var sharing in sharings)
                    {
                        var sourcePrincipalId = sharing.GetAttributeValue<Guid>("principalid");
                        var sourcePrincipalType = sharing.GetAttributeValue<string>("principaltypecode");

                        var targetPrincipal = mappings.FirstOrDefault(m =>
                            m.IsMigrate && m.SourceRecord == sourcePrincipalId &&
                            m.EntityType == sourcePrincipalType)?.DestinationRecord;

                        if (!targetPrincipal.HasValue)
                        {
                            continue;
                        }

                        destinationInstance.Execute(new GrantAccessRequest()
                        {
                            PrincipalAccess = new PrincipalAccess()
                            {
                                AccessMask = sharing.GetAttributeValue<AccessRights>("accessrightsmask"),
                                Principal = new EntityReference(sourcePrincipalType, targetPrincipal.Value)
                            },
                            Target = viewCopy.ToEntityReference()
                        });
                    }
                }
            });
        }

        private void MigratePersonalCharts(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var destinationInstance = AdditionalConnectionDetails[AdditionalConnectionDetails.Count - 1]
                .GetCrmServiceClient(true);

            var selectedCharts = personalCharts.Where(r => r.IsSelected).ToList();

            selectedCharts.ForEach(chart =>
            {
                var sourceOwnerId = chart.Record.GetAttributeValue<EntityReference>("ownerid").Id;
                var destinationOwnerId =
                    mappings.FirstOrDefault(t => t.SourceRecord == sourceOwnerId)?.DestinationRecord;

                if (!destinationOwnerId.HasValue)
                {
                    return;
                }

                ((OrganizationServiceProxy)Service).CallerId = sourceOwnerId;

                destinationInstance.CallerId = destinationOwnerId.Value;

                var chartCopy = chart.Record.Copy("charttype", "datadescription", "description", "isdefault", "name", "presentationdescription", "primaryentitytypecode", "userqueryvisualizationid", "webresourceid");

                chartCopy["ownerid"] = new EntityReference("systemuser", destinationOwnerId.Value);

                destinationInstance.Upsert(chartCopy);

                if ((MigrationType)args.Argument == MigrationType.ViewAndShares)
                {

                    var sharings = RetrieveSharings(Service, chart.Record.ToEntityReference());

                    foreach (var sharing in sharings)
                    {
                        var sourcePrincipalId = sharing.GetAttributeValue<Guid>("principalid");
                        var sourcePrincipalType = sharing.GetAttributeValue<string>("principaltypecode");

                        var targetPrincipal = mappings.FirstOrDefault(m =>
                            m.IsMigrate && m.SourceRecord == sourcePrincipalId &&
                            m.EntityType == sourcePrincipalType)?.DestinationRecord;

                        if (!targetPrincipal.HasValue)
                        {
                            continue;
                        }

                        destinationInstance.Execute(new GrantAccessRequest()
                        {
                            PrincipalAccess = new PrincipalAccess()
                            {
                                AccessMask = sharing.GetAttributeValue<AccessRights>("accessrightsmask"),
                                Principal = new EntityReference(sourcePrincipalType, targetPrincipal.Value)
                            },
                            Target = chartCopy.ToEntityReference()
                        });
                    }
                }
            });
        }

        private void MigratePersonalDashboards(BackgroundWorker worked, DoWorkEventArgs args)
        {
            var destinationInstance = AdditionalConnectionDetails[AdditionalConnectionDetails.Count - 1]
                .GetCrmServiceClient(true);

            var selectedDashboards = personalDashboards.Where(r => r.IsSelected).ToList();

            selectedDashboards.ForEach(db =>
            {
                var sourceOwnerId = db.Record.GetAttributeValue<EntityReference>("ownerid").Id;
                var destinationOwnerId =
                    mappings.FirstOrDefault(t => t.SourceRecord == sourceOwnerId)?.DestinationRecord;

                if (!destinationOwnerId.HasValue)
                {
                    return;
                }

                ((OrganizationServiceProxy)Service).CallerId = sourceOwnerId;

                destinationInstance.CallerId = destinationOwnerId.Value;

                var dbCopy = db.Record.Copy("description", "formjson", "formxml", "istabletenabled", "name", "objecttypecode", "ownerid", "type", "userformid");

                dbCopy["ownerid"] = new EntityReference("systemuser", destinationOwnerId.Value);

                destinationInstance.Upsert(dbCopy);

                if ((MigrationType) args.Argument == MigrationType.ViewAndShares)
                {

                    var sharings = RetrieveSharings(Service, db.Record.ToEntityReference());

                    foreach (var sharing in sharings)
                    {
                        var sourcePrincipalId = sharing.GetAttributeValue<Guid>("principalid");
                        var sourcePrincipalType = sharing.GetAttributeValue<string>("principaltypecode");

                        var targetPrincipal = mappings.FirstOrDefault(m =>
                            m.IsMigrate && m.SourceRecord == sourcePrincipalId &&
                            m.EntityType == sourcePrincipalType)?.DestinationRecord;

                        if (!targetPrincipal.HasValue)
                        {
                            continue;
                        }

                        destinationInstance.Execute(new GrantAccessRequest()
                        {
                            PrincipalAccess = new PrincipalAccess()
                            {
                                AccessMask = sharing.GetAttributeValue<AccessRights>("accessrightsmask"),
                                Principal = new EntityReference(sourcePrincipalType, targetPrincipal.Value)
                            },
                            Target = dbCopy.ToEntityReference()
                        });
                    }
                }
            });
        }

        private void tvPrivateViews_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var checkedNode = e.Node;
            IterativeCheck(checkedNode);

            if (checkedNode.Name == "Record")
            {
                personalViews.Where(t => t.RecordId == (Guid)checkedNode.Tag).ToList().ForEach(t => t.IsSelected = checkedNode.Checked);
            }
        }

        private void tvPersonalCharts_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var checkedNode = e.Node;
            IterativeCheck(checkedNode);

            if (checkedNode.Name == "Record")
            {
                personalCharts.Where(t => t.RecordId == (Guid)checkedNode.Tag).ToList().ForEach(t => t.IsSelected = checkedNode.Checked);
            }
        }

        private void tvPersonalDashboards_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var checkedNode = e.Node;
            IterativeCheck(checkedNode);

            if (checkedNode.Name == "Record")
            {
                personalDashboards.Where(t => t.RecordId == (Guid)checkedNode.Tag).ToList().ForEach(t => t.IsSelected = checkedNode.Checked);
            }
        }

        private void IterativeCheck(TreeNode treeNode)
        {
            foreach (TreeNode childNode in treeNode.Nodes)
            {
                childNode.Checked = treeNode.Checked;
                IterativeCheck(childNode);
            }
        }
    }
}