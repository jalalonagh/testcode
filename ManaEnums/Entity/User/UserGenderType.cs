using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaEnums.Entity.User
{
    public enum UserGenderType
    {
        [Display(Name = "آقا")]
        MALE = 1,
        [Display(Name = "خانم")]
        FEMALE = 2
    }
}
