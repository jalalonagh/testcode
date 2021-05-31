using ManaViewModel.Common;

namespace ManaViewModel.SMSConfirmation
{
    public class SMSConfirmationVMSearch : BaseSearchVM<SMSConfirmationVMSearch, Entities.SMSConfirmation.SMSConfirmationSearch, int>
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public string confirmationText { get; set; }
    }
}
