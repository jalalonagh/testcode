using Entities.User;
using Services.Base.Contracts;
using Services.Models;
using System.Threading.Tasks;

namespace Services.Services.UserService
{
    public interface IUserServices : IBaseService<Entities.User.User>
    {
        Task<IServiceResult> Autorization();
        Task<IServiceResult<Entities.User.User>> GetByUsername(string username);
        Task<IServiceResult<Entities.User.User>> GetByEmail(string email);
        Task<IServiceResult<JWTAuthModel>> Token(TokenRequest tokenRequest, string url);
        Task<IServiceResult<Entities.User.User>> SyncUser(string username, Entities.User.User userData);
        Task<IServiceResult<Entities.User.User>> SyncUser(TokenRequest tokenRequest, Entities.User.User userData);
        Task<IServiceResult<Entities.User.User>> Create(User userData, string url);
        Task<IServiceResult<User>> ResetPassword(string userName);
        Task<IServiceResult<Entities.User.User>> ChangeThePassword(string userName, string currentPassword, string newPassword);
    }
}
