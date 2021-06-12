using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;
using System.Collections.Generic;

namespace ManaViewModel.Profile
{
    public class ProfileVM : BaseVM<ProfileVM, Entities.Profile.Profile, int>, IHaveCustomMapping
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberId { get; set; }
        public PhoneNumber.PhoneNumberVM Number { get; set; }
        public string TeleNumber { get; set; }
        public string NationalCode { get; set; }
        public string EmailAddress { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public string Avatar { get; set; }
        public int Points { get; set; }
        public int? ProfileTypeId { get; set; }
        public string CardNo { get; set; }
        public string SecondPassword { get; set; }
        public string AccountingId { get; set; }
        public string ExtensionNumber { get; set; }

        public IEnumerable<FavoriteProduct.FavoriteProductVM> FavoriteProducts { get; set; }
    }
}