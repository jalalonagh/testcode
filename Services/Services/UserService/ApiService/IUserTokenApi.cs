using Entities.User;
using Services.Models;
using System.Threading.Tasks;

namespace Services.Services.UserService.ApiService
{
    public interface IUserTokenApi
    {
        Task<ServiceResult> GetUserFormServer(string username, string url);
        Task<ServiceResult> GetToken(string username, string password, string url);
        Task<ServiceResult> CreateUserIntoServer(User user, string url);
        Task<ServiceResult> ResetPasswordIntoServer(User user, string url);
        Task<ServiceResult> ChangeThePassword(string userName, string currentPassword, string newPassword, string url);
    }
}
