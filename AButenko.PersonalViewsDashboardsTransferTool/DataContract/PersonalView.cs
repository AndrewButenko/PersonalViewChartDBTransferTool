using Microsoft.Xrm.Sdk;

namespace AButenko.PersonalViewsDashboardsTransferTool.DataContract
{
    public class PersonalView: PersonalRecordBase
    {
        #region CTOR

        public PersonalView(Entity record):base(record)
        {
            EntityTypeName = record.GetAttributeValue<string>("returnedtypecode");
        }

        #endregion CTOR

        #region Properties

        public string EntityTypeName { get; private set; }

        #endregion Properties

    }
}
