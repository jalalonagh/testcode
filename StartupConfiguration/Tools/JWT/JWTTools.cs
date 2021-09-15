using Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StartupConfiguration.Models;
using System;
using System.Linq;
using System.Security.Claims;

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

        public static JwtBearerEvents GenerateJWTBearerEvent<USER, REPO>(this JWTSettings settings)
            where USER : IdentityUser
            where REPO : class
        {
            return new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<USER>>();
                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                    if (claimsIdentity.Claims?.Any() != true)
                        context.Fail("This token has no claims.");
                    var securityStamp = claimsIdentity.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
                    if (!string.IsNullOrEmpty(securityStamp))
                        context.Fail("This token has no secuirty stamp");
                    var userId = claimsIdentity.GetUserId<int>();
                    if (userId <= 0)
                    {
                        context.Fail("شناسه یافت نشد");
                    }
                }
            };
        }
    }
}
