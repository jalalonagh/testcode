using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;

namespace ManaViewModel.Phone
{
    public class PhoneVM : BaseVM<PhoneVM, Entities.Phone.Phone, int>, IHaveCustomMapping
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public int? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
