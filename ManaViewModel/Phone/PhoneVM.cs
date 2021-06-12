using ManaAutoMapper.Interfaces;
using ManaEnums.Entity.Phone;
using ManaViewModel.Common;

namespace ManaViewModel.Phone
{
    public class PhoneVM : BaseVM<PhoneVM, Entities.Phone.Phone, int>, IHaveCustomMapping
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public PhoneType? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
