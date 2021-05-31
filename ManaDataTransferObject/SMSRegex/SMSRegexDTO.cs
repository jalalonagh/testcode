using ManaDataTransferObject.Common;
using ManaEnums.SMSText;

namespace ManaDataTransferObject.SMSRegex
{
    public class SMSRegexDTO : BaseDTO<SMSRegexDTO, Entities.SMSRegex.SMSRegex, int>
    {
        public string regex { get; set; }
        public SMSRegexType type { get; set; }
    }
}
