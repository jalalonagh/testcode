using Common;
using Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JwtService : IJwtService, IScopedDependency
    {
        private readonly SiteSettings _siteSetting;
        private readonly SignInManager<User> signInManager;

        public JwtService(IOptionsSnapshot<SiteSettings> settings, SignInManager<User> signInManager)
        {
            _siteSetting = settings.Value;
            this.signInManager = signInManager;
        }

        public async Task<AccessToken> GenerateAsync(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.SecretKey); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
            var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.Encryptkey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            var claims = await _getClaimsAsync(user);
            var descriptor = GenerateDiscribtor(signingCredentials, encryptingCredentials, claims);
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);
            return new AccessToken(securityToken);
        }

        public async Task<IEnumerable<Claim>> ReadClaimsAsync(string token)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.SecretKey); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
            var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.Encryptkey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadJwtToken(token);
            IEnumerable<Claim> claims = securityToken.Claims;
            return claims;
        }

        private SecurityTokenDescriptor GenerateDiscribtor(SigningCredentials signing, EncryptingCredentials encrypting, IEnumerable<Claim> claims)
        {
            return new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.JwtSettings.Issuer,
                Audience = _siteSetting.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.ExpirationMinutes),
                SigningCredentials = signing,
                EncryptingCredentials = encrypting,
                Subject = new ClaimsIdentity(claims)
            };
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(User user)
        {
            var list = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            return list;
        }
    }
}
