using Entities.User;
using Services.Base.Contracts;
using Services.Models;
using System.Threading.Tasks;

namespace Services.Services.UserService
{
    public interface IUserServices : IBaseService<Entities.User.User>
    {
        Task<ServiceResult> Autorization();
        Task<ServiceResult> GetByUsername(string username);
        Task<ServiceResult> GetByEmail(string email);
        Task<ServiceResult> Token(TokenRequest tokenRequest, string url);
        Task<ServiceResult> SyncUser(string username, Entities.User.User userData);
        Task<ServiceResult> SyncUser(TokenRequest tokenRequest, Entities.User.User userData);
        Task<ServiceResult> Create(User userData, string url);
        Task<ServiceResult> ResetPassword(string userName);
        Task<ServiceResult> ChangeThePassword(string userName, string currentPassword, string newPassword);
    }
}
