using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile
{
    public class ProfileDTO : BaseDTO<ProfileDTO, Entities.Profile.Profile, int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneId { get; set; }
        public string TelePhone { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public int? YearBirthDate { get; set; }
        public int? MonthBirthDate { get; set; }
        public int? DayBirthDate { get; set; }
        public string Image { get; set; }
        public int Points { get; set; }
        public int? ProfileTypeId { get; set; }
        public string BankCardNo { get; set; }
        public string SecondPassword { get; set; }
        public string AccountingId { get; set; }
        public string ExtensionNumber { get; set; }
    }
}