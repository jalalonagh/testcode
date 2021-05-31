using ManaViewModel.Common;

namespace ManaViewModel.SMSConfirmation
{
    public class SMSConfirmationVM : BaseVM<SMSConfirmationVM, Entities.SMSConfirmation.SMSConfirmation, int>
    {
        public int phoneId { get; set; }
        public Phone.PhoneVM phone { get; set; }
        public int smsId { get; set; }
        public SMS.SMSVM sms { get; set; }
        public string confirmationText { get; set; }
    }
}
