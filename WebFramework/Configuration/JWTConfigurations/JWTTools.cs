using Common;
using Common.Utilities;
using Data.User;
using Entities.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebFramework.Configuration.JWTConfigurations
{
    public static class JWTTools
    {
        public static TokenValidationParameters GenerateValidationParameters(this JwtSettings settings, byte[] secretkey, byte[] encryptionkey)
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

        public static JwtBearerEvents GenerateJWTBearerEvent(this JwtSettings settings)
        {
            return new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<User>>();
                    var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                    if (claimsIdentity.Claims?.Any() != true)
                        context.Fail("This token has no claims.");
                    var securityStamp = claimsIdentity.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
                    if (!securityStamp.HasValue())
                        context.Fail("This token has no secuirty stamp");
                    var userId = claimsIdentity.GetUserId<int>();
                    var user = await userRepository.GetByIdAsync(context.HttpContext.RequestAborted, userId);
                    if (user == null)
                    {
                        context.Fail("کاربر یافت نشد.");
                        return;
                    }
                    if (user.IsSuccess && user.Data.IsActive)
                        context.Fail("User is not active.");
                    await userRepository.UpdateLastLoginDateAsync(user.Data);
                }
            };
        }
    }
}
