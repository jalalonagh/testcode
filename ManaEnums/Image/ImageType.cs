using System.ComponentModel.DataAnnotations;

namespace ManaEnums.Image
{
    public enum ImageType
    {
        [Display(Name = "اصلی")]
        MAIN = 1,
        [Display(Name = "فشرده شده")]
        COMPRESSED = 2
    }
}
