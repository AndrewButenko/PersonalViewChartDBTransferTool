using System;
using Microsoft.Xrm.Sdk;

namespace AButenko.PersonalViewsDashboardsTransferTool.DataContract
{
    public class Record
    {
        #region CTOR

        private Record()
        {
            throw new Exception("Don't use default CTOR!");
        }

        public Record(Entity sourceRecord)
        {
            if (sourceRecord == null)
            {
                throw new ArgumentNullException(nameof(sourceRecord));
            }

            Id = sourceRecord.Id;
            EntityType = sourceRecord.LogicalName;

            switch (EntityType)
            {
                case "systemuser":
                    DisplayName = $"{sourceRecord.GetAttributeValue<string>("fullname")} (User)";
                    break;
                case "team":
                    DisplayName = $"{sourceRecord.GetAttributeValue<string>("name")} (Team)";
                    break;
                default:
                    throw new NotImplementedException($"{EntityType} is not supported");
            }
        }

        #endregion CTOR

        #region Properties

        public Guid Id { get; }
        public string EntityType { get; }
        public string DisplayName { get; }

        #endregion Properties
    }

    public class RecordMapping
    {
        public bool IsMigrate { get; set; }
        public Guid SourceRecord { get; set; }
        public Guid? DestinationRecord { get; set; }
        public string EntityType { get; set; }
    }
}
