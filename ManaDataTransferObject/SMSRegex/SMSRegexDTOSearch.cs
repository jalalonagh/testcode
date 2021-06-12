using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;
using ManaEnums.SMSText;

namespace ManaDataTransferObject.SMSRegex
{
    public class SMSRegexDTOSearch : BaseSearchDTO<SMSRegexDTOSearch, Entities.SMSRegex.SMSRegexSearch, int>
    {
        public string regex { get; set; }
        public SMSRegexType? type { get; set; }
    }
}
