using Entities.Common;

namespace Entities.SMSConfirmation
{
    public class SMSConfirmation : BaseEntity
    {
        public int phoneId { get; set; }
        public Phone.Phone phone { get; set; }
        public int smsId { get; set; }
        public SMS.SMS sms { get; set; }
        public string confirmationText { get; set; }
    }
}
