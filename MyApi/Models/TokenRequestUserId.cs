using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class TokenRequestUserId
    {
        [Required]
        public int userId { get; set; }
    }
}
