using Entities.User;
using Services.Models;
using System.Threading.Tasks;

namespace Services.Services.UserService.ApiService
{
    public interface IUserTokenApi
    {
        Task<ServiceResult<Entities.User.User>> GetUserFormServer(string username, string url);
        Task<ServiceResult<JWTAuthModel>> GetToken(string username, string password, string url);
        Task<ServiceResult<User>> CreateUserIntoServer(User user, string url);
        Task<ServiceResult<User>> ResetPasswordIntoServer(User user, string url);
        Task<ServiceResult<Entities.User.User>> ChangeThePassword(string userName, string currentPassword, string newPassword, string url);
    }
}
