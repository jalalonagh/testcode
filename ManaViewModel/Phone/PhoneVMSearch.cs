using ManaViewModel.Common;

namespace ManaViewModel.Phone
{
    public class PhoneSearchVM : BaseSearchVM<PhoneSearchVM, Entities.Phone.PhoneSearch, int>
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public int? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
