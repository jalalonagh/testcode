using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;
using ManaEnums.Entity.Phone;

namespace ManaDataTransferObject.Phone
{
    public class PhoneDTO : BaseDTO<PhoneDTO, Entities.Phone.Phone, int>, IHaveCustomMapping
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public PhoneType? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
