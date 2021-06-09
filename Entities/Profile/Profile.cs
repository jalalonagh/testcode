using System.Collections.Generic;

namespace Entities.Profile
{
    public class Profile : BaseEntity
    {
        public User.User User { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumberId { get; set; }
        public string TelePhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string EmailAddress { get; set; }
        public int? YearBirthDate { get; set; }
        public int? MonthBirthDate { get; set; }
        public int? DayBirthDate { get; set; }
        public string ImageAddress { get; set; }
        public int Points { get; set; }
        public int? ProfileTypeId { get; set; }
        public string BankCarNo { get; set; }
        public string SecondPassword { get; set; }
        public string AccountingSystemId { get; set; }
        public string ExtensionNumber { get; set; }

        public IEnumerable<FavoriteProduct.FavoriteProduct> FavoriteProducts { get; set; }
        public IEnumerable<PhoneNumber.PhoneNumber> Phones { get; set; }
    }
}