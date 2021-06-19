using System.ComponentModel.DataAnnotations;

namespace ManaEnums.Database
{
    public enum SchemaEnum
    {
        [Display(Name = "پیام کوتاه")]
        SMS,
        [Display(Name = "تلفن")]
        PHONE,
        [Display(Name = "تراکنش ها")]
        TRANSACTION,
        [Display(Name = "پروفایل")]
        PROFILE,
        [Display(Name = "الگو ها")]
        REGEX,
        [Display(Name = "کاربر")]
        USER,
        [Display(Name = "تامین کننده")]
        SUPPLIER
    }
}