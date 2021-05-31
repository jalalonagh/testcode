using Entities.User;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        public AccessToken(JwtSecurityToken securityToken)
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token_type = "Bearer";
            expires_in = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
        }
    }

    public class AccessTokenDto
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        //public AccessToken(JwtSecurityToken securityToken)
        //{
        //    access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        //    token_type = "Bearer";
        //    expires_in = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
        //}
    }

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
