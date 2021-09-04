using Common;
using Data;
using Data.User;
using Entities.User;
using ManaBaseData.Repositories;
using ManaBaseEntity.Common;
using ManaEnums.Api;
using ManaResourceManager;
using ManaSpeedTester;
using ManaSpeedTester.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.Base.Services;
using Services.Models;
using Services.Services.UserService.ApiService;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Services.UserService
{
    public class UserServices : BaseService<User>, IUserServices, IScopedDependency
    {
        public IUserRepository repository { get; set; }
        private TimeDurationTrackerSingleton tester;
        private ResourceManagerSingleton resource;
        private IUserTokenApi tokenApi;
        private readonly SiteSettings settings;
        private readonly IHostingEnvironment env;

        public UserServices(IUserRepository repository,
            IUserTokenApi _tokenApi,
            IHostingEnvironment _env,
            IOptions<SiteSettings> _settings) : base(repository)
        {
            this.repository = repository;
            tester = TimeDurationTrackerSingleton.Instance;
            tokenApi = _tokenApi;
            settings = _settings.Value;
            resource = ResourceManagerSingleton.GetInstance();
            env = _env;
        }

        public async Task<ServiceResult> Autorization()
        {
            var token = await Token(new TokenRequest
            {
                Password = settings.Password,
                Username = settings.UserName,
                GrantType = "password"
            }, settings.UriUserInfo);
            new ConnectionApi(env).saveToken(new AccessToken
            {
                access_token = token.GetData<JWTAuthModel>().jwt.access_token
            });
            return new ServiceResult(true, ApiResultStatus.SUCCESS);
        }
        public async Task<ServiceResult> GetByUsername(string username)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var api = await tokenApi.GetUserFormServer(username, settings.UriUserInfo);
            var query = repository
                .Entities
                .Where(w => w.UserName == username)
                .AsQueryable();
            foreach (var property in repository.Entities.GetContext<User>().Model.FindEntityType(typeof(IEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<User>();
            var feilds = query.GetOrderFeilds<User>();
            query = query.SetOrder<User>(feilds);
            var result = await query.FirstOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), username));      // SAVE SPEEDT TEST RESULT
            return api;
        }
        public async Task<ServiceResult> GetByEmail(string email)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var query = repository
                .Entities
                .Where(w => w.Email == email)
                .AsQueryable();
            foreach (var property in repository.Entities.GetContext<User>().Model.FindEntityType(typeof(IEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<User>();
            var feilds = query.GetOrderFeilds<User>();
            query = query.SetOrder<User>(feilds);
            var result = await query.FirstOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), email));      // SAVE SPEEDT TEST RESULT
            return true.GenerateResult<User>(ApiResultStatus.SUCCESS, result, "");
        }
        public async Task<ServiceResult> Token(TokenRequest tokenRequest, string url)
        {
            var api = await tokenApi.GetToken(tokenRequest.Username, tokenRequest.Password, settings.UriUserInfo);
            var apiUser = api.GetData<JWTAuthModel>().user;
            if (api.IsSuccess)
            {
                var user2 = await repository.Entities.FindAsync(apiUser.Id);
                if (user2 == null)
                {
                    return api;
                }
                if (user2 != null)
                    apiUser.UserType = user2.UserType;
                if (!string.IsNullOrWhiteSpace(apiUser.Avatar))
                    apiUser.Avatar = apiUser.Avatar.Replace("C:\\inetpub\\wwwroot\\User\\wwwroot\\uploads\\", "https://token.dinavision.org/uploads/");
            }
            return api;
        }
        public async Task<ServiceResult> SyncUser(string username, Entities.User.User userData)
        {
            var userServer = await GetByUsername(username);
            if (!userServer.GetIsSuccess())
            {
                var result = await AddAsync(userData);
                return result;
            }
            return new ServiceResult(false, ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("errorinuserdatasync").GetMessage());
        }
        public async Task<ServiceResult> SyncUser(TokenRequest tokenRequest, Entities.User.User userData)
        {
            var userServer = await GetByUsername(tokenRequest.Username);
            if (!userServer.GetIsSuccess())
            {
                var result = await AddAsync(userData);
                return result;
            }
            return new ServiceResult(false, ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("errorinuserdatasync").GetMessage());
        }
        public async Task<ServiceResult> Create(User userData, string url)
        {
            var response = await tokenApi.CreateUserIntoServer(userData, url);
            if (response.IsSuccess)
            {
                Random random = new Random();
                var code = random.Next(56793, 99999);
                var user = new Entities.User.User
                {
                    Id = response.GetData<User>().Id,
                    Age = userData.Age,
                    Email = userData.Email,
                    FullName = userData.FullName,
                    UserName = userData.UserName,
                    Gender = userData.Gender,
                    PhoneNumber = userData.PhoneNumber,
                    NikName = userData.NikName,
                    ValidCode = code.ToString(),
                    ValidCodeExpired = DateTime.Now.AddMinutes(settings.ValidCodeExpired),
                    IsPerson = userData.IsPerson,
                    IsActive = true,
                    SalcustTp = userData.SalcustTp,
                    SalcustSi = userData.SalcustSi,
                    SalcustCu = userData.SalcustCu
                };
                if ((await GetByIdAsync(user.Id)).GetIsSuccess())
                    await AddAsync(user);
                return true.GenerateResult<User>(ApiResultStatus.SUCCESS, user);
            }
            return response;
        }
        public async Task<ServiceResult> ResetPassword(string userName)
        {
            var user = await GetByUsername(userName);
            if (user.GetIsSuccess())
                return await tokenApi.ResetPasswordIntoServer(user.GetData<User>(), settings.UriUserInfo);
            return false.GenerateResult<User>(ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("usernotfound").GetMessage());
        }
        public async Task<ServiceResult> ChangeThePassword(string userName, string currentPassword, string newPassword)
        {
            List<ManaResourceManager.Models.ResourceItemPack> messages = new List<ManaResourceManager.Models.ResourceItemPack>();
            if (!string.IsNullOrEmpty(userName))
                messages.Add(resource.FetchResource("usernameisrequired"));
            if (!string.IsNullOrEmpty(currentPassword))
                messages.Add(resource.FetchResource("currentpasswordisrequired"));
            if (!string.IsNullOrEmpty(newPassword))
                messages.Add(resource.FetchResource("newpasswordisrequired"));
            if (messages.Count() > 0)
                return new ServiceResult(false, ApiResultStatus.BAD_REQUEST, null, string.Join(", ", messages.Select(s => s.GetMessage())));
            return await tokenApi.ChangeThePassword(userName, currentPassword, newPassword, settings.UriUserInfo);
        }
    }
}
