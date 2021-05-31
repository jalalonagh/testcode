using ManaEnums.SMSText;
using ManaViewModel.Common;

namespace ManaViewModel.SMSRegex
{
    public class SMSRegexVM : BaseVM<SMSRegexVM, Entities.SMSRegex.SMSRegex, int>
    {
        public string regex { get; set; }
        public SMSRegexType type { get; set; }
    }
}
