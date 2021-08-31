using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;

namespace ManaViewModel.Profile.PhoneNumber
{
    public class PhoneNumberVM : BaseVM<PhoneNumberVM, Entities.Profile.PhoneNumber.PhoneNumber, int>, IHaveCustomMapping
    {
        public PhoneNumberType.PhoneNumberTypeVM PhoneNumberType { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string Number { get; set; }
        public ProfileVM Profile { get; set; }
    }
}