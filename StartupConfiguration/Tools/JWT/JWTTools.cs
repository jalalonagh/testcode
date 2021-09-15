using Microsoft.IdentityModel.Tokens;
using StartupConfiguration.Models;
using System;

namespace StartupConfiguration.Tools.JWT
{
    public static class JWTTools
    {
        public static TokenValidationParameters GenerateValidationParameters(this JWTSettings settings, byte[] secretkey, byte[] encryptionkey)
        {
            return new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkey),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = settings.Audience,
                ValidateIssuer = true,
                ValidIssuer = settings.Issuer,
                TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
            };
        }
    }
}
