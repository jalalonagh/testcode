using ManaBaseEntity.Common;

namespace Entities.SMSRegex
{
    public class SMSRegexSearch : BaseSearchEntity
    {
        public string regex { get; set; }
        public int? type { get; set; }
    }
}
