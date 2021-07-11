using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
