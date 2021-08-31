using System.ComponentModel.DataAnnotations;

namespace ManaEnums.Entity.Phone
{
    public enum PhoneType
    {
        [Display(Name = "خانه")]
        HOME = 0,
        [Display(Name = "اداره")]
        WORK = 1,
        [Display(Name = "دفتر")]
        OFFICE = 2,
        [Display(Name = "بانک")]
        BANK = 3,
        [Display(Name = "دوست")]
        FREIND = 4,
        [Display(Name = "کارمند")]
        EMPLOYEE = 5,
        [Display(Name = "رئیس")]
        BUS = 6,
        [Display(Name = "مدیر")]
        MANAGER = 7,
        [Display(Name = "شخص")]
        PERSON = 8,
    }
}
