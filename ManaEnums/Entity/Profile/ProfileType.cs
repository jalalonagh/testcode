using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaEnums.Entity.Profile
{
    public enum ProfileType
    {
        [Display(Name = "همکار")]
        CO_WORKER = 1,
        [Display(Name = "شرکت")]
        COMPANY = 2,
        [Display(Name = "مصرف کننده")]
        END_USER = 3,
        [Display(Name = "تعمیر کار")]
        MECHANIC = 4,
        [Display(Name = "F9 تعمیر کار")]
        MECHANIC_F9 = 5
    }
}
