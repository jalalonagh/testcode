using ManaAutoMapper.Interfaces;
using ManaEnums.SMSText;
using ManaViewModel.Common;

namespace ManaViewModel.SMSRegex
{
    public class SMSRegexVM : BaseVM<SMSRegexVM, Entities.SMSRegex.SMSRegex, int>, IHaveCustomMapping
    {
        public string regex { get; set; }
        public int type { get; set; }
    }
}
