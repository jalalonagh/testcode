using System.Threading;
using System.Threading.Tasks;
using Common;
using Entities.User;
using Microsoft.AspNetCore.Http;
using ViewModels.Sale;
using ViewModels.User;

namespace Services
{
    public interface IUserService
    {
        Task<ServiceResult> Autorization();
        Task<ServiceResult> ChangeThePassword(string userName, string currentPassword, string newPassword, CancellationToken cancellationToken);
        Task<ServiceResult<Entities.User.User>> Create(UserDto userDto, CancellationToken cancellationToken);
        Task<ServiceResult<Entities.User.User>> Get(string username, CancellationToken cancellationToken);
        Task<ServiceResult<Entities.User.User>> GetByEmail(string email, CancellationToken cancellationToken);
        Task<ServiceResult<string>> ResetPassword(string userName, CancellationToken cancellationToken);
        Task<ServiceResult<dto>> Token(TokenRequest tokenRequest, CancellationToken cancellationToken);
        Task<ServiceResult<dto>> Token(TokenRequestUserId tokenRequest, CancellationToken cancellationToken);
        Task<ServiceResult<GoogleAccessToken>> GoogleToken(GoogleSigninModel model, CancellationToken cancellationToken);
        Task<ServiceResult> Update(string username, IFormFile file, CancellationToken cancellationToken);
        Task<ServiceResult> ValidPhone(string username, string code);
        Task<ServiceResult<Entities.User.User>> Update(int id, UserEditDto user, CancellationToken cancellationToken);
        Task<ServiceResult> AgainSendValidCode(string userName, CancellationToken cancellationToken);
        Task<ServiceResult<Entities.User.User>> GetByPhoneNumber(string phoeNumber, CancellationToken cancellationToken);
        Task<ServiceResult> EditPhoneNumber(string userName, string phoneNumber);
        Task<ServiceResult> SuspendedUserVerify(SuspendedUser model, Type type);
        Task<ServiceResult<string>> ResetPasswordByValidation(UserPasswordResertDTO model, CancellationToken cancellationToken);
        Task<ServiceResult<Entities.User.User>> CreateWithValidation(UserDto userDto, CancellationToken cancellationToken);
        Task<ServiceResult> EditFullName(string userName, string fullName);
        Task<ServiceResult> RegisterSuspendedUser(SuspendedUser model, Type type);
        Task<ServiceResult> AgainSendValidCodeForSuspendedUser(SuspendedUser model, Type type, CancellationToken cancellationToken);
        Task<ServiceResult<Entities.User.User>> SyncUser(TokenRequest tokenRequest, Entities.User.User user2);
        Task<Entities.User.User> SyncUser(string username, Entities.User.User user2);
        Task<ServiceResult> EditEmailAddress(string username, string emailAddress);
        Task<ServiceResult<Entities.User.User>> SyncUser(TokenRequestUserId tokenRequest, Entities.User.User user2);
        Task<ServiceResult<Entities.User.User>> Get(int id, CancellationToken cancellationToken);
        Task<ServiceResult> CreateUserChair(int userId, int? chairId, CancellationToken cancellationToken);
    }
}