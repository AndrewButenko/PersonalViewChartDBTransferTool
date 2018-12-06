namespace AButenko.PersonalViewsDashboardsTransferTool
{
    partial class PvdbTransferToolPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgMapping = new System.Windows.Forms.DataGridView();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUserTeamMapping = new System.Windows.Forms.TabPage();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.menuUserMapping = new System.Windows.Forms.MenuStrip();
            this.loadUsersAndTeamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPrivateViewsList = new System.Windows.Forms.TabPage();
            this.tvPrivateViews = new System.Windows.Forms.TreeView();
            this.menuPersonalViews = new System.Windows.Forms.MenuStrip();
            this.loadPrivateViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migratePrivateViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddViewsMigrationType = new System.Windows.Forms.ToolStripComboBox();
            this.tabPersonalCharts = new System.Windows.Forms.TabPage();
            this.tvPersonalCharts = new System.Windows.Forms.TreeView();
            this.menuPersonalCharts = new System.Windows.Forms.MenuStrip();
            this.menuItemLoadPersonalCharts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMigratePersonalCharts = new System.Windows.Forms.ToolStripMenuItem();
            this.ddPersonalChartsMigrationType = new System.Windows.Forms.ToolStripComboBox();
            this.tabPersonalDashboards = new System.Windows.Forms.TabPage();
            this.menuPersonalDashboard = new System.Windows.Forms.MenuStrip();
            this.loadPersonalDashboardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migratePersonalDashboardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSourceInstance = new System.Windows.Forms.GroupBox();
            this.btnConnectToSource = new System.Windows.Forms.Button();
            this.lblSourceConnectionState = new System.Windows.Forms.Label();
            this.lblSourceConnectionStateLabel = new System.Windows.Forms.Label();
            this.gbDestinationInstance = new System.Windows.Forms.GroupBox();
            this.btnConnectToDestination = new System.Windows.Forms.Button();
            this.lblDestinationConnectionState = new System.Windows.Forms.Label();
            this.lblDestinationConnectionStateLabel = new System.Windows.Forms.Label();
            this.ddPersonalDashboardMigrationType = new System.Windows.Forms.ToolStripComboBox();
            this.tvPersonalDashboards = new System.Windows.Forms.TreeView();
            this.isMigrateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sourceRecordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.destinationRecordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.recordMappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgMapping)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabUserTeamMapping.SuspendLayout();
            this.menuUserMapping.SuspendLayout();
            this.tabPrivateViewsList.SuspendLayout();
            this.menuPersonalViews.SuspendLayout();
            this.tabPersonalCharts.SuspendLayout();
            this.menuPersonalCharts.SuspendLayout();
            this.tabPersonalDashboards.SuspendLayout();
            this.menuPersonalDashboard.SuspendLayout();
            this.gbSourceInstance.SuspendLayout();
            this.gbDestinationInstance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordMappingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMapping
            // 
            this.dgMapping.AllowUserToAddRows = false;
            this.dgMapping.AllowUserToDeleteRows = false;
            this.dgMapping.AutoGenerateColumns = false;
            this.dgMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isMigrateDataGridViewCheckBoxColumn,
            this.sourceRecordDataGridViewTextBoxColumn,
            this.destinationRecordDataGridViewTextBoxColumn});
            this.dgMapping.DataSource = this.recordMappingBindingSource;
            this.dgMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMapping.Location = new System.Drawing.Point(2, 26);
            this.dgMapping.Margin = new System.Windows.Forms.Padding(2);
            this.dgMapping.Name = "dgMapping";
            this.dgMapping.RowTemplate.Height = 24;
            this.dgMapping.Size = new System.Drawing.Size(698, 330);
            this.dgMapping.TabIndex = 5;
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabUserTeamMapping);
            this.tabMain.Controls.Add(this.tabPrivateViewsList);
            this.tabMain.Controls.Add(this.tabPersonalCharts);
            this.tabMain.Controls.Add(this.tabPersonalDashboards);
            this.tabMain.Location = new System.Drawing.Point(2, 101);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(710, 384);
            this.tabMain.TabIndex = 6;
            // 
            // tabUserTeamMapping
            // 
            this.tabUserTeamMapping.Controls.Add(this.cbSelectAll);
            this.tabUserTeamMapping.Controls.Add(this.dgMapping);
            this.tabUserTeamMapping.Controls.Add(this.menuUserMapping);
            this.tabUserTeamMapping.Location = new System.Drawing.Point(4, 22);
            this.tabUserTeamMapping.Margin = new System.Windows.Forms.Padding(2);
            this.tabUserTeamMapping.Name = "tabUserTeamMapping";
            this.tabUserTeamMapping.Padding = new System.Windows.Forms.Padding(2);
            this.tabUserTeamMapping.Size = new System.Drawing.Size(702, 358);
            this.tabUserTeamMapping.TabIndex = 0;
            this.tabUserTeamMapping.Text = "User/Team Mapping";
            this.tabUserTeamMapping.UseVisualStyleBackColor = true;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Checked = true;
            this.cbSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSelectAll.Location = new System.Drawing.Point(92, 31);
            this.cbSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(15, 14);
            this.cbSelectAll.TabIndex = 6;
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // menuUserMapping
            // 
            this.menuUserMapping.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuUserMapping.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadUsersAndTeamsToolStripMenuItem});
            this.menuUserMapping.Location = new System.Drawing.Point(2, 2);
            this.menuUserMapping.Name = "menuUserMapping";
            this.menuUserMapping.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuUserMapping.Size = new System.Drawing.Size(698, 24);
            this.menuUserMapping.TabIndex = 7;
            this.menuUserMapping.Text = "menuStrip3";
            // 
            // loadUsersAndTeamsToolStripMenuItem
            // 
            this.loadUsersAndTeamsToolStripMenuItem.Enabled = false;
            this.loadUsersAndTeamsToolStripMenuItem.Name = "loadUsersAndTeamsToolStripMenuItem";
            this.loadUsersAndTeamsToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.loadUsersAndTeamsToolStripMenuItem.Text = "Load Users and Teams";
            this.loadUsersAndTeamsToolStripMenuItem.Click += new System.EventHandler(this.btnLoadUsers_Click);
            // 
            // tabPrivateViewsList
            // 
            this.tabPrivateViewsList.Controls.Add(this.tvPrivateViews);
            this.tabPrivateViewsList.Controls.Add(this.menuPersonalViews);
            this.tabPrivateViewsList.Location = new System.Drawing.Point(4, 22);
            this.tabPrivateViewsList.Margin = new System.Windows.Forms.Padding(2);
            this.tabPrivateViewsList.Name = "tabPrivateViewsList";
            this.tabPrivateViewsList.Padding = new System.Windows.Forms.Padding(2);
            this.tabPrivateViewsList.Size = new System.Drawing.Size(702, 358);
            this.tabPrivateViewsList.TabIndex = 1;
            this.tabPrivateViewsList.Text = "Personal Views";
            this.tabPrivateViewsList.UseVisualStyleBackColor = true;
            // 
            // tvPrivateViews
            // 
            this.tvPrivateViews.CheckBoxes = true;
            this.tvPrivateViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPrivateViews.Location = new System.Drawing.Point(2, 29);
            this.tvPrivateViews.Margin = new System.Windows.Forms.Padding(2);
            this.tvPrivateViews.Name = "tvPrivateViews";
            this.tvPrivateViews.Size = new System.Drawing.Size(698, 327);
            this.tvPrivateViews.TabIndex = 2;
            this.tvPrivateViews.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPrivateViews_AfterCheck);
            // 
            // menuPersonalViews
            // 
            this.menuPersonalViews.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPersonalViews.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPrivateViewsToolStripMenuItem,
            this.migratePrivateViewsToolStripMenuItem,
            this.ddViewsMigrationType});
            this.menuPersonalViews.Location = new System.Drawing.Point(2, 2);
            this.menuPersonalViews.Name = "menuPersonalViews";
            this.menuPersonalViews.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuPersonalViews.Size = new System.Drawing.Size(698, 27);
            this.menuPersonalViews.TabIndex = 0;
            this.menuPersonalViews.Text = "menuStrip1";
            // 
            // loadPrivateViewsToolStripMenuItem
            // 
            this.loadPrivateViewsToolStripMenuItem.Name = "loadPrivateViewsToolStripMenuItem";
            this.loadPrivateViewsToolStripMenuItem.Size = new System.Drawing.Size(126, 23);
            this.loadPrivateViewsToolStripMenuItem.Text = "Load Personal Views";
            this.loadPrivateViewsToolStripMenuItem.Click += new System.EventHandler(this.loadPrivateViewsToolStripMenuItem_Click);
            // 
            // migratePrivateViewsToolStripMenuItem
            // 
            this.migratePrivateViewsToolStripMenuItem.Name = "migratePrivateViewsToolStripMenuItem";
            this.migratePrivateViewsToolStripMenuItem.Size = new System.Drawing.Size(141, 23);
            this.migratePrivateViewsToolStripMenuItem.Text = "Migrate Personal Views";
            this.migratePrivateViewsToolStripMenuItem.Click += new System.EventHandler(this.migratePrivateViewsToolStripMenuItem_Click);
            // 
            // ddViewsMigrationType
            // 
            this.ddViewsMigrationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddViewsMigrationType.Items.AddRange(new object[] {
            "Migrate Views and Shares",
            "Migrate Views Only"});
            this.ddViewsMigrationType.Name = "ddViewsMigrationType";
            this.ddViewsMigrationType.Size = new System.Drawing.Size(175, 23);
            // 
            // tabPersonalCharts
            // 
            this.tabPersonalCharts.Controls.Add(this.tvPersonalCharts);
            this.tabPersonalCharts.Controls.Add(this.menuPersonalCharts);
            this.tabPersonalCharts.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalCharts.Name = "tabPersonalCharts";
            this.tabPersonalCharts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalCharts.Size = new System.Drawing.Size(702, 358);
            this.tabPersonalCharts.TabIndex = 3;
            this.tabPersonalCharts.Text = "Personal Charts";
            this.tabPersonalCharts.UseVisualStyleBackColor = true;
            // 
            // tvPersonalCharts
            // 
            this.tvPersonalCharts.CheckBoxes = true;
            this.tvPersonalCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPersonalCharts.Location = new System.Drawing.Point(3, 30);
            this.tvPersonalCharts.Margin = new System.Windows.Forms.Padding(2);
            this.tvPersonalCharts.Name = "tvPersonalCharts";
            this.tvPersonalCharts.Size = new System.Drawing.Size(696, 325);
            this.tvPersonalCharts.TabIndex = 4;
            this.tvPersonalCharts.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPersonalCharts_AfterCheck);
            // 
            // menuPersonalCharts
            // 
            this.menuPersonalCharts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPersonalCharts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoadPersonalCharts,
            this.menuItemMigratePersonalCharts,
            this.ddPersonalChartsMigrationType});
            this.menuPersonalCharts.Location = new System.Drawing.Point(3, 3);
            this.menuPersonalCharts.Name = "menuPersonalCharts";
            this.menuPersonalCharts.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuPersonalCharts.Size = new System.Drawing.Size(696, 27);
            this.menuPersonalCharts.TabIndex = 3;
            this.menuPersonalCharts.Text = "menuStrip4";
            // 
            // menuItemLoadPersonalCharts
            // 
            this.menuItemLoadPersonalCharts.Name = "menuItemLoadPersonalCharts";
            this.menuItemLoadPersonalCharts.Size = new System.Drawing.Size(130, 23);
            this.menuItemLoadPersonalCharts.Text = "Load Personal Charts";
            this.menuItemLoadPersonalCharts.Click += new System.EventHandler(this.menuItemLoadPersonalCharts_Click);
            // 
            // menuItemMigratePersonalCharts
            // 
            this.menuItemMigratePersonalCharts.Name = "menuItemMigratePersonalCharts";
            this.menuItemMigratePersonalCharts.Size = new System.Drawing.Size(145, 23);
            this.menuItemMigratePersonalCharts.Text = "Migrate Personal Charts";
            this.menuItemMigratePersonalCharts.Click += new System.EventHandler(this.menuItemMigratePersonalCharts_Click);
            // 
            // ddPersonalChartsMigrationType
            // 
            this.ddPersonalChartsMigrationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddPersonalChartsMigrationType.Items.AddRange(new object[] {
            "Migrate Charts and Shares",
            "Migrate Charts Only"});
            this.ddPersonalChartsMigrationType.Name = "ddPersonalChartsMigrationType";
            this.ddPersonalChartsMigrationType.Size = new System.Drawing.Size(175, 23);
            // 
            // tabPersonalDashboards
            // 
            this.tabPersonalDashboards.Controls.Add(this.tvPersonalDashboards);
            this.tabPersonalDashboards.Controls.Add(this.menuPersonalDashboard);
            this.tabPersonalDashboards.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalDashboards.Margin = new System.Windows.Forms.Padding(2);
            this.tabPersonalDashboards.Name = "tabPersonalDashboards";
            this.tabPersonalDashboards.Padding = new System.Windows.Forms.Padding(2);
            this.tabPersonalDashboards.Size = new System.Drawing.Size(702, 358);
            this.tabPersonalDashboards.TabIndex = 2;
            this.tabPersonalDashboards.Text = "Personal Dashboards";
            this.tabPersonalDashboards.UseVisualStyleBackColor = true;
            // 
            // menuPersonalDashboard
            // 
            this.menuPersonalDashboard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPersonalDashboard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPersonalDashboardsToolStripMenuItem,
            this.migratePersonalDashboardsToolStripMenuItem,
            this.ddPersonalDashboardMigrationType});
            this.menuPersonalDashboard.Location = new System.Drawing.Point(2, 2);
            this.menuPersonalDashboard.Name = "menuPersonalDashboard";
            this.menuPersonalDashboard.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuPersonalDashboard.Size = new System.Drawing.Size(698, 27);
            this.menuPersonalDashboard.TabIndex = 0;
            this.menuPersonalDashboard.Text = "menuStrip2";
            // 
            // loadPersonalDashboardsToolStripMenuItem
            // 
            this.loadPersonalDashboardsToolStripMenuItem.Name = "loadPersonalDashboardsToolStripMenuItem";
            this.loadPersonalDashboardsToolStripMenuItem.Size = new System.Drawing.Size(158, 23);
            this.loadPersonalDashboardsToolStripMenuItem.Text = "Load Personal Dashboards";
            this.loadPersonalDashboardsToolStripMenuItem.Click += new System.EventHandler(this.loadPrivateDashboardsToolStripMenuItem_Click);
            // 
            // migratePersonalDashboardsToolStripMenuItem
            // 
            this.migratePersonalDashboardsToolStripMenuItem.Name = "migratePersonalDashboardsToolStripMenuItem";
            this.migratePersonalDashboardsToolStripMenuItem.Size = new System.Drawing.Size(173, 23);
            this.migratePersonalDashboardsToolStripMenuItem.Text = "Migrate Personal Dashboards";
            this.migratePersonalDashboardsToolStripMenuItem.Click += new System.EventHandler(this.migratePrivateDashboardsToolStripMenuItem_Click);
            // 
            // gbSourceInstance
            // 
            this.gbSourceInstance.Controls.Add(this.btnConnectToSource);
            this.gbSourceInstance.Controls.Add(this.lblSourceConnectionState);
            this.gbSourceInstance.Controls.Add(this.lblSourceConnectionStateLabel);
            this.gbSourceInstance.Location = new System.Drawing.Point(18, 10);
            this.gbSourceInstance.Margin = new System.Windows.Forms.Padding(2);
            this.gbSourceInstance.Name = "gbSourceInstance";
            this.gbSourceInstance.Padding = new System.Windows.Forms.Padding(2);
            this.gbSourceInstance.Size = new System.Drawing.Size(202, 86);
            this.gbSourceInstance.TabIndex = 7;
            this.gbSourceInstance.TabStop = false;
            this.gbSourceInstance.Text = "Source Instance";
            // 
            // btnConnectToSource
            // 
            this.btnConnectToSource.Location = new System.Drawing.Point(65, 51);
            this.btnConnectToSource.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnectToSource.Name = "btnConnectToSource";
            this.btnConnectToSource.Size = new System.Drawing.Size(56, 19);
            this.btnConnectToSource.TabIndex = 2;
            this.btnConnectToSource.Text = "Connect";
            this.btnConnectToSource.UseVisualStyleBackColor = true;
            this.btnConnectToSource.Click += new System.EventHandler(this.btnConnectToSource_Click);
            // 
            // lblSourceConnectionState
            // 
            this.lblSourceConnectionState.AutoSize = true;
            this.lblSourceConnectionState.ForeColor = System.Drawing.Color.Red;
            this.lblSourceConnectionState.Location = new System.Drawing.Point(100, 25);
            this.lblSourceConnectionState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSourceConnectionState.Name = "lblSourceConnectionState";
            this.lblSourceConnectionState.Size = new System.Drawing.Size(79, 13);
            this.lblSourceConnectionState.TabIndex = 1;
            this.lblSourceConnectionState.Text = "Not Connected";
            // 
            // lblSourceConnectionStateLabel
            // 
            this.lblSourceConnectionStateLabel.AutoSize = true;
            this.lblSourceConnectionStateLabel.Location = new System.Drawing.Point(5, 26);
            this.lblSourceConnectionStateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSourceConnectionStateLabel.Name = "lblSourceConnectionStateLabel";
            this.lblSourceConnectionStateLabel.Size = new System.Drawing.Size(92, 13);
            this.lblSourceConnectionStateLabel.TabIndex = 0;
            this.lblSourceConnectionStateLabel.Text = "Connection State:";
            // 
            // gbDestinationInstance
            // 
            this.gbDestinationInstance.Controls.Add(this.btnConnectToDestination);
            this.gbDestinationInstance.Controls.Add(this.lblDestinationConnectionState);
            this.gbDestinationInstance.Controls.Add(this.lblDestinationConnectionStateLabel);
            this.gbDestinationInstance.Location = new System.Drawing.Point(244, 10);
            this.gbDestinationInstance.Margin = new System.Windows.Forms.Padding(2);
            this.gbDestinationInstance.Name = "gbDestinationInstance";
            this.gbDestinationInstance.Padding = new System.Windows.Forms.Padding(2);
            this.gbDestinationInstance.Size = new System.Drawing.Size(202, 86);
            this.gbDestinationInstance.TabIndex = 8;
            this.gbDestinationInstance.TabStop = false;
            this.gbDestinationInstance.Text = "Destination Instance";
            // 
            // btnConnectToDestination
            // 
            this.btnConnectToDestination.Location = new System.Drawing.Point(65, 51);
            this.btnConnectToDestination.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnectToDestination.Name = "btnConnectToDestination";
            this.btnConnectToDestination.Size = new System.Drawing.Size(56, 19);
            this.btnConnectToDestination.TabIndex = 2;
            this.btnConnectToDestination.Text = "Connect";
            this.btnConnectToDestination.UseVisualStyleBackColor = true;
            this.btnConnectToDestination.Click += new System.EventHandler(this.btnConnectToTarget_Click);
            // 
            // lblDestinationConnectionState
            // 
            this.lblDestinationConnectionState.AutoSize = true;
            this.lblDestinationConnectionState.ForeColor = System.Drawing.Color.Red;
            this.lblDestinationConnectionState.Location = new System.Drawing.Point(100, 25);
            this.lblDestinationConnectionState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDestinationConnectionState.Name = "lblDestinationConnectionState";
            this.lblDestinationConnectionState.Size = new System.Drawing.Size(79, 13);
            this.lblDestinationConnectionState.TabIndex = 1;
            this.lblDestinationConnectionState.Text = "Not Connected";
            // 
            // lblDestinationConnectionStateLabel
            // 
            this.lblDestinationConnectionStateLabel.AutoSize = true;
            this.lblDestinationConnectionStateLabel.Location = new System.Drawing.Point(5, 26);
            this.lblDestinationConnectionStateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDestinationConnectionStateLabel.Name = "lblDestinationConnectionStateLabel";
            this.lblDestinationConnectionStateLabel.Size = new System.Drawing.Size(92, 13);
            this.lblDestinationConnectionStateLabel.TabIndex = 0;
            this.lblDestinationConnectionStateLabel.Text = "Connection State:";
            // 
            // ddPersonalDashboardMigrationType
            // 
            this.ddPersonalDashboardMigrationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddPersonalDashboardMigrationType.Items.AddRange(new object[] {
            "Migrate Dashboards and Shares",
            "Migrate Dashboards Only"});
            this.ddPersonalDashboardMigrationType.Name = "ddPersonalDashboardMigrationType";
            this.ddPersonalDashboardMigrationType.Size = new System.Drawing.Size(200, 23);
            // 
            // tvPersonalDashboards
            // 
            this.tvPersonalDashboards.CheckBoxes = true;
            this.tvPersonalDashboards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPersonalDashboards.Location = new System.Drawing.Point(2, 29);
            this.tvPersonalDashboards.Margin = new System.Windows.Forms.Padding(2);
            this.tvPersonalDashboards.Name = "tvPersonalDashboards";
            this.tvPersonalDashboards.Size = new System.Drawing.Size(698, 327);
            this.tvPersonalDashboards.TabIndex = 5;
            this.tvPersonalDashboards.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPersonalDashboards_AfterSelect);
            // 
            // isMigrateDataGridViewCheckBoxColumn
            // 
            this.isMigrateDataGridViewCheckBoxColumn.DataPropertyName = "IsMigrate";
            this.isMigrateDataGridViewCheckBoxColumn.HeaderText = "Migrate";
            this.isMigrateDataGridViewCheckBoxColumn.Name = "isMigrateDataGridViewCheckBoxColumn";
            // 
            // sourceRecordDataGridViewTextBoxColumn
            // 
            this.sourceRecordDataGridViewTextBoxColumn.DataPropertyName = "SourceRecord";
            this.sourceRecordDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceRecordDataGridViewTextBoxColumn.Name = "sourceRecordDataGridViewTextBoxColumn";
            this.sourceRecordDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceRecordDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sourceRecordDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sourceRecordDataGridViewTextBoxColumn.Width = 150;
            // 
            // destinationRecordDataGridViewTextBoxColumn
            // 
            this.destinationRecordDataGridViewTextBoxColumn.DataPropertyName = "DestinationRecord";
            this.destinationRecordDataGridViewTextBoxColumn.HeaderText = "Destination";
            this.destinationRecordDataGridViewTextBoxColumn.Name = "destinationRecordDataGridViewTextBoxColumn";
            this.destinationRecordDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.destinationRecordDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.destinationRecordDataGridViewTextBoxColumn.Width = 150;
            // 
            // recordMappingBindingSource
            // 
            this.recordMappingBindingSource.DataSource = typeof(AButenko.PersonalViewsDashboardsTransferTool.DataContract.RecordMapping);
            // 
            // PvdbTransferToolPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDestinationInstance);
            this.Controls.Add(this.gbSourceInstance);
            this.Controls.Add(this.tabMain);
            this.Name = "PvdbTransferToolPluginControl";
            this.Size = new System.Drawing.Size(712, 488);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMapping)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabUserTeamMapping.ResumeLayout(false);
            this.tabUserTeamMapping.PerformLayout();
            this.menuUserMapping.ResumeLayout(false);
            this.menuUserMapping.PerformLayout();
            this.tabPrivateViewsList.ResumeLayout(false);
            this.tabPrivateViewsList.PerformLayout();
            this.menuPersonalViews.ResumeLayout(false);
            this.menuPersonalViews.PerformLayout();
            this.tabPersonalCharts.ResumeLayout(false);
            this.tabPersonalCharts.PerformLayout();
            this.menuPersonalCharts.ResumeLayout(false);
            this.menuPersonalCharts.PerformLayout();
            this.tabPersonalDashboards.ResumeLayout(false);
            this.tabPersonalDashboards.PerformLayout();
            this.menuPersonalDashboard.ResumeLayout(false);
            this.menuPersonalDashboard.PerformLayout();
            this.gbSourceInstance.ResumeLayout(false);
            this.gbSourceInstance.PerformLayout();
            this.gbDestinationInstance.ResumeLayout(false);
            this.gbDestinationInstance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordMappingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgMapping;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMigrateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sourceRecordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn destinationRecordDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource recordMappingBindingSource;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUserTeamMapping;
        private System.Windows.Forms.TabPage tabPrivateViewsList;
        private System.Windows.Forms.TabPage tabPersonalDashboards;
        private System.Windows.Forms.MenuStrip menuPersonalViews;
        private System.Windows.Forms.ToolStripMenuItem loadPrivateViewsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuPersonalDashboard;
        private System.Windows.Forms.ToolStripMenuItem loadPersonalDashboardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migratePrivateViewsToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.ToolStripMenuItem migratePersonalDashboardsToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbSourceInstance;
        private System.Windows.Forms.Button btnConnectToSource;
        private System.Windows.Forms.Label lblSourceConnectionState;
        private System.Windows.Forms.Label lblSourceConnectionStateLabel;
        private System.Windows.Forms.GroupBox gbDestinationInstance;
        private System.Windows.Forms.Button btnConnectToDestination;
        private System.Windows.Forms.Label lblDestinationConnectionState;
        private System.Windows.Forms.Label lblDestinationConnectionStateLabel;
        private System.Windows.Forms.MenuStrip menuUserMapping;
        private System.Windows.Forms.ToolStripMenuItem loadUsersAndTeamsToolStripMenuItem;
        private System.Windows.Forms.TreeView tvPrivateViews;
        private System.Windows.Forms.ToolStripComboBox ddViewsMigrationType;
        private System.Windows.Forms.TabPage tabPersonalCharts;
        private System.Windows.Forms.TreeView tvPersonalCharts;
        private System.Windows.Forms.MenuStrip menuPersonalCharts;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadPersonalCharts;
        private System.Windows.Forms.ToolStripMenuItem menuItemMigratePersonalCharts;
        private System.Windows.Forms.ToolStripComboBox ddPersonalChartsMigrationType;
        private System.Windows.Forms.TreeView tvPersonalDashboards;
        private System.Windows.Forms.ToolStripComboBox ddPersonalDashboardMigrationType;
    }
}
