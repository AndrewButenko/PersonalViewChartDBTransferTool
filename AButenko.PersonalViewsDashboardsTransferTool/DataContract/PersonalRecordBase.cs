using System;
using Microsoft.Xrm.Sdk;

namespace AButenko.PersonalViewsDashboardsTransferTool.DataContract
{
    public abstract class PersonalRecordBase
    {
        #region CTOR

        protected PersonalRecordBase(Entity record)
        {
            Record = record;
            RecordId = record.Id;
            IsSelected = true;
            Name = record.GetAttributeValue<string>("name");
            Owner = $"{record.GetAttributeValue<EntityReference>("ownerid").Name}({record.GetAttributeValue<EntityReference>("ownerid").LogicalName})";
            OwnerId = record.GetAttributeValue<EntityReference>("ownerid").Id;
        }

        #endregion CTOR

        #region Properties

        public Entity Record { get; private set; }
        public Guid RecordId { get; private set; }
        public bool IsSelected { get; set; }
        public string Name { get; private set; }
        public string Owner { get; private set; }
        public Guid OwnerId { get; private set; }

        #endregion Properties
    }
}
