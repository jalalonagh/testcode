using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GoogleAccessToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public Entities.User.User user { get; set; }

        public GoogleAccessToken()
        {

        }

        public GoogleAccessToken(JwtSecurityToken securityToken)
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token_type = "Bearer";
            expires_in = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
        }

        public GoogleAccessToken(AccessToken token)
        {
            access_token = token.access_token;
            token_type = token.token_type;
            expires_in = token.expires_in;
            refresh_token = token.refresh_token;
        }
    }
}
