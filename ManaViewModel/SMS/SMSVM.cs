using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;

namespace ManaViewModel.SMS
{
    public class SMSVM : BaseVM<SMSVM, Entities.SMS.SMS, int>, IHaveCustomMapping
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}