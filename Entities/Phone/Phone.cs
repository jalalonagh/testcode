using ManaEnums.Entity.Phone;

namespace Entities.Phone
{
    public class Phone : BaseEntity
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public PhoneType? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
