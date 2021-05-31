using ManaEnums.Entity.Phone;
using ManaViewModel.Common;

namespace ManaViewModel.Profile.PhoneNumber
{
    public class PhoneNumberVM : BaseVM<PhoneNumberVM, Entities.Profile.PhoneNumber.PhoneNumber, int>
    {
        public PhoneNumberType.PhoneNumberTypeVM PhoneNumberType { get; set; }
        public PhoneType PhoneNumberTypeId { get; set; }
        public string Number { get; set; }
        public ProfileVM Profile { get; set; }
    }
}