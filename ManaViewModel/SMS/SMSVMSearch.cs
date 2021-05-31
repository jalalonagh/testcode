using ManaViewModel.Common;

namespace ManaViewModel.SMS
{
    public class SMSVMSearch : BaseSearchVM<SMSVM, Entities.SMS.SMSSearch, int>
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}