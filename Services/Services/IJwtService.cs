using Entities.User;
using Services.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
        Task<IEnumerable<Claim>> ReadClaimsAsync(string token);
    }
}