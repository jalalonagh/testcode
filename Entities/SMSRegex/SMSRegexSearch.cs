using Entities.Common;
using ManaEnums.SMSText;

namespace Entities.SMSRegex
{
    public class SMSRegexSearch : BaseSearchEntity
    {
        public string regex { get; set; }
        public SMSRegexType? type { get; set; }
    }
}
