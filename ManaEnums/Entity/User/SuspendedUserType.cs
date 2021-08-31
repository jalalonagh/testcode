using System.ComponentModel.DataAnnotations;

namespace ManaEnums.Entity.User
{
    public enum SuspendedUserType
    {
        [Display(Name = "تغییر رمز")]
        RESET_PASSWORD = 0,
        [Display(Name = "ساخت کاربری")]
        CREATE_USER = 1
    }
}
