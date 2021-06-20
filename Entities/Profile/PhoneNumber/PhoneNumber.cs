using ManaBaseEntity.Common;

namespace Entities.Profile.PhoneNumber
{
    public class PhoneNumber : BaseEntity
    {
        public int PhoneNumberTypeId { get; set; }
        public PhoneNumberType.PhoneNumberType PhoneNumberType { get; set; }
        public string Number { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}