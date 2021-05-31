using ManaViewModel.Common;

namespace ManaViewModel.SMS
{
    public class SMSVM : BaseVM<SMSVM, Entities.SMS.SMS, int>
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}