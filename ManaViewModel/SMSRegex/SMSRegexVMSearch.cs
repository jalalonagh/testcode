using ManaEnums.SMSText;
using ManaViewModel.Common;

namespace ManaViewModel.SMSRegex
{
    public class SMSRegexVMSearch : BaseSearchVM<SMSRegexVMSearch, Entities.SMSRegex.SMSRegexSearch, int>
    {
        public string regex { get; set; }
        public int? type { get; set; }
    }
}
