using ManaBaseEntity.Common;

namespace Entities.SMSRegex
{
    public class SMSRegex : BaseEntity
    {
        public string regex { get; set; }
        public int type { get; set; }
    }
}
