using Entities.User;
using Services.Base.Contracts;
using Services.Models;
using System.Threading.Tasks;

namespace Services.Services.UserService
{
    public interface IUserServices : IBaseService<Entities.User.User, UserSearch>
    {
        Task<ServiceResult> Autorization();
        Task<ServiceResult<Entities.User.User>> GetByUsername(string username);
        Task<ServiceResult<Entities.User.User>> GetByEmail(string email);
        Task<ServiceResult<JWTAuthModel>> Token(TokenRequest tokenRequest, string url);
        Task<ServiceResult<Entities.User.User>> SyncUser(string username, Entities.User.User userData);
        Task<ServiceResult<Entities.User.User>> SyncUser(TokenRequest tokenRequest, Entities.User.User userData);
        Task<ServiceResult<Entities.User.User>> Create(User userData, string url);
        Task<ServiceResult<User>> ResetPassword(string userName);
        Task<ServiceResult<Entities.User.User>> ChangeThePassword(string userName, string currentPassword, string newPassword);
    }
}
