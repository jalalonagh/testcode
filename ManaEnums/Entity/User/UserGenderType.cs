using System.ComponentModel.DataAnnotations;

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
