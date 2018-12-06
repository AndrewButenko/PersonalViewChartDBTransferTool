using Microsoft.Xrm.Sdk;

namespace AButenko.PersonalViewsDashboardsTransferTool.DataContract
{
    public class PersonalChart: PersonalRecordBase
    {
        #region CTOR

        public PersonalChart(Entity record) : base(record)
        {
            EntityTypeName = record.GetAttributeValue<string>("primaryentitytypecode");
        }

        #endregion 

        #region Properties

        public string EntityTypeName { get; private set; }

        #endregion Properties
    }
}
