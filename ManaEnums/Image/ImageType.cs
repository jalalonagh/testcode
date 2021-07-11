using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
