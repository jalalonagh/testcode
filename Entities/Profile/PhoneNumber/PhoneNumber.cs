using ManaEnums.Entity.Phone;

namespace Entities.Profile.PhoneNumber
{
    public class PhoneNumber : BaseEntity
    {
        public PhoneNumberType.PhoneNumberType PhoneNumberType { get; set; }
        public PhoneType PhoneNumberTypeId { get; set; }
        public string Number { get; set; }
        public Profile Profile { get; set; }
    }
}