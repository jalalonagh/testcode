using Common;
using Data;
using Data.Repositories;
using Entities.Common;
using Entities.User;
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
    public class UserServices : BaseService<User, UserSearch>, IUserServices, IScopedDependency
    {
        public IRepository<User, UserSearch> repository { get; set; }
        private TimeDurationTrackerSingleton tester;
        private ResourceManagerSingleton resource;
        private IUserTokenApi tokenApi;
        private readonly SiteSettings settings;
        private readonly IHostingEnvironment env;

        public UserServices(IRepository<User,
            UserSearch> repository,
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
                access_token = token.Data.jwt.access_token
            });
            return new ServiceResult(true, ApiResultStatus.SUCCESS);
        }
        public async Task<ServiceResult<Entities.User.User>> GetByUsername(string username)
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
            query = query.SetOrder<User, UserSearch>(feilds);
            var result = await query.FirstOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), username));      // SAVE SPEEDT TEST RESULT
            return api;
        }
        public async Task<ServiceResult<Entities.User.User>> GetByEmail(string email)
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
            query = query.SetOrder<User, UserSearch>(feilds);
            var result = await query.FirstOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), email));      // SAVE SPEEDT TEST RESULT
            return result;
        }
        public async Task<ServiceResult<JWTAuthModel>> Token(TokenRequest tokenRequest, string url)
        {
            var api = await tokenApi.GetToken(tokenRequest.Username, tokenRequest.Password, settings.UriUserInfo);
            if (api.IsSuccess)
            {
                var user2 = await repository.Entities.FindAsync(api.Data.user.Id);
                if (user2 == null)
                {
                    return api;
                }
                var collection = repository.Entities.GetContext<User>().Entry(user2).Reference(x => x.Profile);
                if (!collection.IsLoaded)
                    await collection.LoadAsync();
                api.Data.user.FullName = user2.FullName;
                api.Data.user.Profile = new Entities.Profile.Profile
                {
                    ImageAddress = user2.Profile?.ImageAddress
                };
                if (user2 != null)
                    api.Data.user.UserType = user2.UserType;
                if (!string.IsNullOrWhiteSpace(api.Data.user.Avatar))
                    api.Data.user.Avatar = api.Data.user.Avatar.Replace("C:\\inetpub\\wwwroot\\User\\wwwroot\\uploads\\", "https://token.dinavision.org/uploads/");
            }
            return api;
        }
        public async Task<ServiceResult<Entities.User.User>> SyncUser(string username, Entities.User.User userData)
        {
            var userServer = await GetByUsername(username);
            if (!userServer.IsSuccess)
            {
                var result = await AddAsync(userData);
                return result;
            }
            return new ServiceResult<User>(false, ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("errorinuserdatasync").GetMessage());
        }
        public async Task<ServiceResult<Entities.User.User>> SyncUser(TokenRequest tokenRequest, Entities.User.User userData)
        {
            var userServer = await GetByUsername(tokenRequest.Username);
            if (!userServer.IsSuccess)
            {
                var result = await AddAsync(userData);
                return result;
            }
            return new ServiceResult<User>(false, ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("errorinuserdatasync").GetMessage());
        }
        public async Task<ServiceResult<Entities.User.User>> Create(User userData, string url)
        {
            var response = await tokenApi.CreateUserIntoServer(userData, url);
            if (response.IsSuccess)
            {
                Random random = new Random();
                var code = random.Next(56793, 99999);
                var user = new Entities.User.User
                {
                    Id = response.Data.Id,
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
                if ((await GetByIdAsync(user.Id)).IsSuccess)
                    await AddAsync(user);
                return user;
            }
            return response;
        }
        public async Task<ServiceResult<User>> ResetPassword(string userName)
        {
            var user = await GetByUsername(userName);
            if (user.IsSuccess)
                return await tokenApi.ResetPasswordIntoServer(user.Data, settings.UriUserInfo);
            return new ServiceResult<User>(false, ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("usernotfound").GetMessage());
        }
        public async Task<ServiceResult<Entities.User.User>> ChangeThePassword(string userName, string currentPassword, string newPassword)
        {
            List<ManaResourceManager.Models.ResourceItemPack> messages = new List<ManaResourceManager.Models.ResourceItemPack>();
            if (!string.IsNullOrEmpty(userName))
                messages.Add(resource.FetchResource("usernameisrequired"));
            if (!string.IsNullOrEmpty(currentPassword))
                messages.Add(resource.FetchResource("currentpasswordisrequired"));
            if (!string.IsNullOrEmpty(newPassword))
                messages.Add(resource.FetchResource("newpasswordisrequired"));
            if (messages.Count() > 0)
                return new ServiceResult<User>(false, ApiResultStatus.BAD_REQUEST, null, string.Join(", ", messages.Select(s => s.GetMessage())));
            return await tokenApi.ChangeThePassword(userName, currentPassword, newPassword, settings.UriUserInfo);
        }
    }
}
