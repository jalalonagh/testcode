using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Phone
{
    public class PhoneDTO : BaseDTO<PhoneDTO, Entities.Phone.Phone, int>, IHaveCustomMapping
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public int? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
