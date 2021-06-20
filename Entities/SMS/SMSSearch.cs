using ManaBaseEntity.Common;

namespace Entities.SMS
{
    public class SMSSearch : BaseSearchEntity
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}