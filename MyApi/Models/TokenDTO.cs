using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class TokenDTO
    {
        public AccessTokenDTO jwt { get; set; }
        public Entities.User.User user { get; set; }
        public string ExtentionsNumber { get; set; }
    }
}
