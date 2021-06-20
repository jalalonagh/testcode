using ManaDataTransferObject.Common;
using ManaEnums.Entity.Phone;

namespace ManaDataTransferObject.Phone
{
    public class PhoneSearchDTO : BaseSearchDTO<PhoneSearchDTO, Entities.Phone.PhoneSearch, int>
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public PhoneType? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
