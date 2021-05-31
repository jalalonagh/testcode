using Common;
using Common.Random;
using Common.Resource;
using Common.Utilities;
using Data.Contracts;
using Entities;
using Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Sale;
using ViewModels.User;
using Type = Entities.User.Type;

namespace Services
{
    public class UserService : IUserService, IScopedDependency
    {
        public async Task<ServiceResult> Autorization()
        {
            var token = await Token(new TokenRequest
            {
                password = _siteSettings.Password,
                username = _siteSettings.UserName,
                grant_type = "password"
            }, CancellationToken.None);

            new ConnectionApi(_env).saveToken(new AccessTokenDto
            {
                access_token = token.Data.jwt.access_token
            });

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        private readonly IHostingEnvironment _env;
        private readonly ILogger<UserService> _logger;
        private readonly ResourceManager _resourceManager;
        private readonly IUnitOfWork _uow;
        private readonly IHttpClientFactory _clientFactory;
        private readonly DbSet<Entities.User.User> _user;
        private readonly DbSet<SuspendedUser> _suspendedUser;
        private readonly SiteSettings _siteSettings;

        public UserService(IUnitOfWork uow,
                           IHttpClientFactory clientFactory,
                           IHostingEnvironment env,
                           IOptions<SiteSettings> settings,
                           ILogger<UserService> logger,
                           ResourceManager resourceManager)
        {
            try
            {
                _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
                _env = env;
                _logger = logger;
                _resourceManager = resourceManager;
                _clientFactory = clientFactory;
                _user = _uow.Set<Entities.User.User>();
                _siteSettings = settings.Value;
                _suspendedUser = _uow.Set<SuspendedUser>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task<ServiceResult<Entities.User.User>> Get(string username, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, cancellationToken);
            var api = await getUserFormServer(username);

            var con = _user.Include(z => z.Contacts).ThenInclude(z => z.ContactType).FirstOrDefault(z => z.UserName == username);
            if (con != null)
            {
                if (api.Data != null)
                {
                    api.Data.Contacts = con.Contacts.ToList();
                }
            }

            if (api == null)
            {
                return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.NotFound, null);
            }

            return api;
        }
        public virtual async Task<ServiceResult<Entities.User.User>> Get(int id, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, id, cancellationToken);
            //var api = await getUserFormServer(username);

            var user = _user.Include(z => z.Contacts).ThenInclude(z => z.ContactType).FirstOrDefault(z => z.SalcustSi == id);


            return user;
        }
        public virtual async Task<ServiceResult<Entities.User.User>> GetByEmail(string email, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, email, cancellationToken);

            var con = _user
                .Include(z => z.Contacts)
                .ThenInclude(z => z.ContactType)
                .Where(w => w.Email != null && w.Email == email)
                .FirstOrDefault();

            if (con != null)
                return con;

            return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.NotFound, null, "کاربر وجود ندارد");
        }

        private async Task<ServiceResult<Entities.User.User>> getUserFormServer(string username)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username);
            var url = _siteSettings.UriUserInfo;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url + $"/{username}");

            var response = await client.SendAsync(request);
            var api = JsonConvert.DeserializeObject<ServiceResult<Entities.User.User>>(await response.Content.ReadAsStringAsync());
            return api;
        }

        /// <summary>
        /// This method generate JWT Token
        /// </summary>
        /// <param name="tokenRequest">The information of token request</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ServiceResult<dto>> Token(TokenRequest tokenRequest, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, tokenRequest, cancellationToken);
            var url = _siteSettings.UriUserInfo + "/TokenWithModel";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var formVariables = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", tokenRequest.username),
                new KeyValuePair<string, string>("password", tokenRequest.password)
            };

            var content = new FormUrlEncodedContent(formVariables);

            request.Content = content;

            var response = await client.SendAsync(request, CancellationToken.None);

            var api = JsonConvert.DeserializeObject<ServiceResult<dto>>(await response.Content.ReadAsStringAsync(CancellationToken.None));

            if (api.IsSuccess)
            {
                var user2 = await _user.FindAsync(api.Data.user.Id);
                if (user2 == null)
                {
                    return api;
                }

                var collection = _uow.DbContext.Entry(user2).Reference(x => x.Profile);

                if (!collection.IsLoaded)
                    await collection.LoadAsync(cancellationToken).ConfigureAwait(false);

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

        public virtual async Task<ServiceResult<dto>> Token(TokenRequestUserId tokenRequest, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, tokenRequest, cancellationToken);
            var url = _siteSettings.UriUserInfo + "/TokenWithUserId";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var formVariables = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("userId", tokenRequest.userId.ToString())
            };

            var content = new FormUrlEncodedContent(formVariables);
            request.Content = content;

            var response = await client.SendAsync(request, CancellationToken.None);

            var api = JsonConvert.DeserializeObject<ServiceResult<dto>>(await response.Content.ReadAsStringAsync(CancellationToken.None));

            if (api.IsSuccess)
            {
                var user2 = await _user.FindAsync(api.Data.user.Id);
                if (user2 == null)
                {
                    return api;
                }

                var collection = _uow.DbContext.Entry(user2).Reference(x => x.Profile);

                if (!collection.IsLoaded)
                    await collection.LoadAsync(cancellationToken).ConfigureAwait(false);

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

        public async Task<Entities.User.User> SyncUser(string username, Entities.User.User user2)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, user2);

            var userServer = await _user.Where(w => w.UserName == username).FirstOrDefaultAsync();

            if (userServer == null)
            {
                await _user.AddAsync(user2);

                var result = await _uow.SaveChangesAsync();

                return result > 0 ? user2 : null;
            }

            return userServer;
        }

        public async Task<ServiceResult<Entities.User.User>> SyncUser(TokenRequest tokenRequest, Entities.User.User user2)
        {
            try
            {
                Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, tokenRequest, user2);

                var userServer = await _user.FirstOrDefaultAsync(w => w.UserName == tokenRequest.username);
                if (userServer == null)
                {
                    await _user.AddAsync(user2);
                    var result = await _uow.SaveChangesAsync();

                    if (result > 0)
                        return user2;

                    return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.ServerError, null, _resourceManager.GetString(ResourceKey.FailedCreateUser));
                }

                return new ServiceResult<Entities.User.User>(true, ApiResultStatusCode.Success, user2, _resourceManager.GetString(ResourceKey.AlreadyUserExits));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ServiceResult<Entities.User.User>> SyncUser(TokenRequestUserId tokenRequest, Entities.User.User user2)
        {
            try
            {
                Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, tokenRequest, user2);

                var userServer = await _user.FirstOrDefaultAsync(w => w.Id == tokenRequest.userId);
                if (userServer == null)
                {
                    await _user.AddAsync(user2);
                    var result = await _uow.SaveChangesAsync();

                    if (result > 0)
                        return user2;

                    return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.ServerError, null, _resourceManager.GetString(ResourceKey.FailedCreateUser));
                }

                return new ServiceResult<Entities.User.User>(true, ApiResultStatusCode.Success, user2, _resourceManager.GetString(ResourceKey.AlreadyUserExits));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public virtual async Task<ServiceResult<Entities.User.User>> Create(UserDto userDto, CancellationToken cancellationToken)
        {

            Assert.NotNull(userDto, nameof(userDto), _resourceManager.GetString(ResourceKey.EmptyUser));

            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userDto, cancellationToken);
        again:
            userDto.Email = $"{userDto.UserName}@dinawin.com";

            //logger.LogError("متد Create فراخوانی شد");
            //HttpContext.RiseError(new Exception("متد Create فراخوانی شد"));

            var url = _siteSettings.UriToken;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var userServer = userDto.DeepClone();
            userServer.Contacts = null;

            var content = new StringContent(JsonConvert.SerializeObject(userServer), Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(await response.Content.ReadAsStringAsync());
                throw new ApplicationException(_resourceManager.GetString(ResourceKey.FailedCreateUser));
            }
            var dr = JsonConvert.DeserializeObject<ServiceResult<Entities.User.User>>(await response.Content.ReadAsStringAsync());

            if (dr.StatusCode == ApiResultStatusCode.Success)
            {
                var code = new CreateRandom().RandomNumber4();

                var user = new Entities.User.User
                {
                    Id = dr.Data.Id,
                    Age = userDto.Age,
                    Email = userDto.Email,
                    FullName = userDto.FullName,
                    UserName = userDto.UserName,
                    Gender = userDto.Gender,
                    PhoneNumber = userDto.PhoneNumber,
                    NikName = userDto.NikName,
                    ValidCode = code.ToString(),
                    ValidCodeExpired = DateTime.Now.AddMinutes(_siteSettings.ValidCodeExpired),
                    Contacts = (userDto.Contacts != null && userDto.Contacts.Any()) ? userDto.Contacts.Select(z => new Contact
                    {
                        ContactTypeId = z.ContactType_Id,
                        Value = z.Value
                    }).ToList() : null,
                    IsPerson = userDto.IsPerson,
                    IsActive = true,
                    SalcustTp = userDto.SalcustTp,
                    SalcustSi = userDto.SalcustSi,
                    SalcustCu = userDto.SalcustCu
                };

                // await sendSmsValidCode(userDto.PhoneNumber, code.ToString());
                if (!_user.Exists(z => z.Id == user.Id))
                    await _user.AddAsync(user, CancellationToken.None);
                var suspendUser = _suspendedUser.Where(z => z.PhoneNumber == userDto.UserName).ToList();
                if (suspendUser.Any())
                    _suspendedUser.RemoveRange(suspendUser);
                await _uow.SaveChangesAsync(CancellationToken.None);
                return dr.Data;
            }

            return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.ServerError, dr.Data, dr.Message);
        }

        public async Task<ServiceResult> CreateUserChair(int userId, int? chairId, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userId, chairId, cancellationToken);

            var url = _siteSettings.UriToken + "/SetChairsToUser";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var content = new StringContent(JsonConvert.SerializeObject(new object[] { new { userId, chairId } }), Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request, CancellationToken.None);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(await response.Content.ReadAsStringAsync());
                throw new ApplicationException(_resourceManager.GetString(ResourceKey.FailedCreateUser));
            }
            else
            {
                return new ServiceResult(true, ApiResultStatusCode.Success);
            }
        }

        public async Task<ServiceResult<Entities.User.User>> CreateWithValidation(UserDto userDto, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userDto, cancellationToken);
            var suspendedUser = await _suspendedUser.FirstOrDefaultAsync(w => w.PhoneNumber == userDto.PhoneNumber && w.Type == Type.CreateUser);

            if (suspendedUser == null)
            {
                return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.BadRequest, null, _resourceManager.GetString(ResourceKey.NotCreatingUser));
            }

            if (!suspendedUser.PhoneNumberConfirmated)
            {
                return new ServiceResult<Entities.User.User>
                    (false,
                    ApiResultStatusCode.BadRequest,
                    null,
                    string.Format(_resourceManager.GetString(ResourceKey.NotRegisteredUserPhoneNumber),
                    userDto.PhoneNumber));
            }

            return await Create(userDto, cancellationToken);
        }

        private async Task<ServiceResult> sendSmsValidCode(string phoneNumber, string code)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, phoneNumber, code);
            string urlSms = _siteSettings.UriSms;

            var clientSms = _clientFactory.CreateClient();

            var message = _siteSettings.MessageSendCode.Replace("{code}", code);

            var requestSms = new HttpRequestMessage(HttpMethod.Post, urlSms + $"?phone={phoneNumber}&message={message}");

            await clientSms.SendAsync(requestSms);

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> ValidPhone(string username, string code)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, code);

            var user = _user.FirstOrDefault(z => z.UserName == username);

            if (user == null)
                return new ServiceResult(false, ApiResultStatusCode.NotFound);

            if (DateTime.Now > user.ValidCodeExpired)
            {
                return new ServiceResult(false,
                                        ApiResultStatusCode.LogicError,
                                        _resourceManager.GetString(ResourceKey.FinishedValidationCodeTime));
            }

            if (code == user.ValidCode)
            {
                user.IsActive = true;
                user.PhoneNumberConfirmed = true;
                _user.Update(user);
                var url = _siteSettings.UriUserInfo;
                var request = new HttpRequestMessage(HttpMethod.Get, url + $"/ValidUser?username={username}");


                var client = _clientFactory.CreateClient();
                await client.SendAsync(request);

                await _uow.SaveChangesAsync();
                return new ServiceResult(true, ApiResultStatusCode.Success);
            }
            return new ServiceResult(false, ApiResultStatusCode.BadRequest, _resourceManager.GetString(ResourceKey.WrongValidationCode));
        }

        public virtual async Task<ServiceResult<GoogleAccessToken>> GoogleToken(GoogleSigninModel model, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
            var url = _siteSettings.UriUserInfo + "/GetGoogleToken";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            request.Content = content;

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var api = JsonConvert.DeserializeObject<GoogleAccessToken>(json);

                if (api != null)
                {
                    new ConnectionApi(_env).saveToken(new AccessTokenDto()
                    {
                        access_token = api.access_token,
                        token_type = api.token_type,
                        refresh_token = api.refresh_token,
                        expires_in = api.expires_in
                    });
                    var user2 = _user.Find(api.user.Id);

                    api.user.NikName = api.user?.NikName ?? api.user?.FullName;

                    if (user2 != null)
                        api.user.UserType = user2.UserType;

                    if (!string.IsNullOrWhiteSpace(api.user.Avatar))
                        api.user.Avatar = api.user.Avatar.Replace("C:\\inetpub\\wwwroot\\User\\wwwroot\\uploads\\", "https://token.dinavision.org/uploads/");

                    return api;
                }
            }

            return new ServiceResult<GoogleAccessToken>(false, ApiResultStatusCode.NotFound, null);
        }

        public virtual async Task<ServiceResult<Entities.User.User>> Update(int id, UserEditDto user, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, id, user, cancellationToken);
            Assert.NotNull(user, nameof(user), _resourceManager.GetString(ResourceKey.EmptyUser));
        again:
            var url = _siteSettings.UriUserInfo;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, url + $"/update?id={id}");

            if (user.FullName.Trim() == "")
            {
                user.FullName = "User";
            }

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            request.Content = content;

            var JWToken = new ConnectionApi(_env).openToken().access_token;
            if (!string.IsNullOrEmpty(JWToken))
            {
                request.Headers.Add("Authorization", "Bearer " + JWToken.Replace("\"", ""));
            }


            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(await response.Content.ReadAsStringAsync());
                throw new ApplicationException(_resourceManager.GetString(ResourceKey.FailedUpdateUser));
            }

            var dr = JsonConvert.DeserializeObject<ServiceResult<Entities.User.User>>(await response.Content.ReadAsStringAsync());
            if (dr.IsSuccess)
            {
                var updateUser = await _user.FindAsync(id);
                if (updateUser != null)
                {
                    updateUser.UserName = dr.Data.UserName;
                    updateUser.PasswordHash = dr.Data.PasswordHash;
                    updateUser.FullName = dr.Data.FullName;
                    updateUser.Age = dr.Data.Age;
                    updateUser.Gender = dr.Data.Gender;
                    updateUser.IsActive = dr.Data.IsActive;
                    updateUser.LastLoginDate = dr.Data.LastLoginDate;
                    updateUser.Contacts = (user.Contacts != null && user.Contacts.Any()) ? user.Contacts.Select(z => new Contact
                    {
                        Value = z.Value,
                        ContactTypeId = z.ContactType_Id
                    }).ToList() : null;
                    updateUser.IsPerson = dr.Data.IsPerson;
                    _user.Update(updateUser);
                    _uow.SaveChanges();
                }
                return new ServiceResult<Entities.User.User>(true, ApiResultStatusCode.Success, dr.Data, dr.Message);
            }

            return new ServiceResult<Entities.User.User>(false, ApiResultStatusCode.ServerError, dr.Data, dr.Message);
        }

        public virtual async Task<ServiceResult<string>> ResetPassword(string userName, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userName, cancellationToken);
        again:
            var url = _siteSettings.UriUserInfo + "/ResetPassword";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url + $"?userName={userName}");

            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }

            return JsonConvert.DeserializeObject<ServiceResult<string>>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<ServiceResult<string>> ResetPasswordByValidation(UserPasswordResertDTO model, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
            var suspendedUser = await _suspendedUser.FirstOrDefaultAsync(Z => Z.PhoneNumber == model.Username && Z.Type == Type.ResetPassword);

            if (suspendedUser == null)
                return new ServiceResult<string>(false,
                                                ApiResultStatusCode.NotFound,
                                                string.Format(_resourceManager.GetString(ResourceKey.NotFoundUserWithPhoneNumber),
                                                    model.Username));

            again:
            var url = _siteSettings.UriUserInfo + "/ResetPasswordTwoWizard";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url);


            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }
            _suspendedUser.RemoveRange(_suspendedUser.Where(z => z.PhoneNumber == model.Username));
            await _uow.SaveChangesAsync();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var serviceResultResponse = apiResponse.FromJson<ServiceResult>();
            return new ServiceResult<string>(serviceResultResponse.IsSuccess, serviceResultResponse.StatusCode, serviceResultResponse.Message, null);
        }
        public virtual async Task<ServiceResult> ChangeThePassword(string userName, string currentPassword, string newPassword, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userName, currentPassword, newPassword, cancellationToken);
        again:
            var url = _siteSettings.UriUserInfo + "/ChangeThePassword";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url + $"?userName={userName}&currentPassword={currentPassword}&newPassword={newPassword}");

            var jWToken = new ConnectionApi(_env).openToken().access_token;
            if (!string.IsNullOrEmpty(jWToken))
            {
                request.Headers.Add("Authorization", "Bearer " + jWToken.Replace("\"", ""));
            }
            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }

            return JsonConvert.DeserializeObject<ServiceResult>(await response.Content.ReadAsStringAsync());
        }
        public virtual async Task<ServiceResult> Update(string username, IFormFile file, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, cancellationToken);
        again:
            var url = _siteSettings.UriUserInfo;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, url + $"/{username}");

            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);

            var bytes = new ByteArrayContent(data);

            var multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "file", file.FileName);

            request.Content = multiContent;

            var jWToken = new ConnectionApi(_env).openToken().access_token;
            if (!string.IsNullOrEmpty(jWToken))
            {
                request.Headers.Add("Authorization", "Bearer " + jWToken.Replace("\"", ""));
            }

            var response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }

            var api = JsonConvert.DeserializeObject<ServiceResult>(await response.Content.ReadAsStringAsync());

            return api;
        }

        public async Task<ServiceResult> AgainSendValidCode(string userName, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userName, cancellationToken);
            var user = _user.FirstOrDefault(z => z.UserName == userName);
            if (user == null)
                return new ServiceResult(false, ApiResultStatusCode.NotFound);

            user.ValidCode = new CreateRandom().RandomNumber4().ToString();
            user.ValidCodeExpired = DateTime.Now.AddMinutes(_siteSettings.ValidCodeExpired);
            await sendSmsValidCode(user.PhoneNumber, user.ValidCode);
            await _uow.SaveChangesAsync();
            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public virtual async Task<ServiceResult<Entities.User.User>> GetByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
        again:
            var url = _siteSettings.UriUserInfo;
            var client = _clientFactory.CreateClient();
            var getUrl = $"https://token.dinavision.org/api/v1/UsersInfo/GetByPhoneNumber?phoneNumber={phoneNumber}";
            var request = new HttpRequestMessage(HttpMethod.Get, getUrl);

            var jWToken = new ConnectionApi(_env).openToken()?.access_token;
            if (!string.IsNullOrEmpty(jWToken))
            {
                request.Headers.Add("Authorization", "Bearer " + jWToken.Replace("\"", ""));
            }

            var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }

            var api = JsonConvert.DeserializeObject<ServiceResult<Entities.User.User>>(await response.Content.ReadAsStringAsync());

            if (api.Data == null)
                return null;

            var con = _user.Include(z => z.Contacts).ThenInclude(z => z.ContactType).FirstOrDefault(z => z.UserName == api.Data.UserName);
            if (con != null)
            {
                if (api.Data != null)
                {
                    api.Data.Contacts = con.Contacts.ToList();
                }
            }

            return api;
        }

        public async Task<ServiceResult> EditPhoneNumber(string username, string phoneNumber)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, phoneNumber);
            var user = _user.FirstOrDefault(z => z.UserName == username);
            if (user == null)
                return new ServiceResult(false, ApiResultStatusCode.NotFound);


            if (user.UserName == user.PhoneNumber)
            {
                user.UserName = phoneNumber;
            }
            user.PhoneNumber = phoneNumber;

            var newUserDto = new UserEditDto
            {
                Id = user.Id,
                Age = user.Age,
                FullName = user.FullName,
                Gender = user.Gender,
                IsPerson = user.IsPerson,
                NikName = user.NikName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType
            };
            await Update(user.Id, newUserDto, new CancellationToken());
            await _uow.SaveChangesAsync();

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> EditFullName(string userName, string fullName)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userName, fullName);
            var user = _user.FirstOrDefault(z => z.UserName == userName);
            if (user == null)
                return new ServiceResult(false, ApiResultStatusCode.NotFound);

            user.FullName = fullName;
            await _uow.SaveChangesAsync();

            await Update(user.Id, new UserEditDto
            {
                Age = user.Age,
                Id = user.Id,
                FullName = user.FullName,
                Gender = user.Gender,
                IsPerson = user.IsPerson,
                NikName = user.NikName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                Contacts = user.Contacts?.Select(x => new ContactEdite { ContactType_Id = x.ContactTypeId, Value = x.Value })
            }, CancellationToken.None);

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> RegisterSuspendedUser(SuspendedUser model, Type type)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, type);
            var user = await Get(model.PhoneNumber, CancellationToken.None);
            if (type == Type.CreateUser)
            {
                if (user.Data != null)
                {
                    return new ServiceResult(false, ApiResultStatusCode.BadRequest, _resourceManager.GetString(ResourceKey.AlreadyUserWithThisMobilePhoneNumberExists));
                }
            }


            if (type == Type.ResetPassword)
            {
                if (user.Data == null)
                {
                    return new ServiceResult(false, ApiResultStatusCode.NotFound, _resourceManager.GetString(ResourceKey.NotFoundUser));
                }
            }

            var suspendedUser = await _suspendedUser.FirstOrDefaultAsync(Z => Z.PhoneNumber == model.PhoneNumber && Z.Type == type);
            if (suspendedUser == null)
            {
                suspendedUser = new SuspendedUser
                {
                    PhoneNumber = model.PhoneNumber,
                    Type = type
                };
                await _suspendedUser.AddAsync(suspendedUser);
            }

            suspendedUser.ValidCode = new CreateRandom().RandomNumber4().ToString();
            suspendedUser.ValidCodeExpired = DateTime.Now.AddMinutes(_siteSettings.ValidCodeExpired);
            await _uow.SaveChangesAsync();
            await sendSmsValidCode(suspendedUser.PhoneNumber, suspendedUser.ValidCode);

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> SuspendedUserVerify(SuspendedUser model, Type type)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, type);
            var suspendedUser = await _suspendedUser.FirstOrDefaultAsync(Z => Z.PhoneNumber == model.PhoneNumber && Z.Type == type);
            if (suspendedUser == null)
                return new ServiceResult(false, ApiResultStatusCode.NotFound, string.Format(_resourceManager.GetString(ResourceKey.NotFoundUserWithPhoneNumber), model.PhoneNumber));

            if (DateTime.Now > suspendedUser.ValidCodeExpired)
            {
                return new ServiceResult(false, ApiResultStatusCode.LogicError, _resourceManager.GetString(ResourceKey.FinishedValidationCodeTime));
            }

            if (model.ValidCode != suspendedUser.ValidCode)
            {
                return new ServiceResult(false, ApiResultStatusCode.LogicError, _resourceManager.GetString(ResourceKey.WrongValidationCode));
            }

            suspendedUser.PhoneNumberConfirmated = true;

            await _uow.SaveChangesAsync();

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> AgainSendValidCodeForSuspendedUser(SuspendedUser model, Type type, CancellationToken cancellationToken)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, type, cancellationToken);

            var user = _suspendedUser.FirstOrDefault(z => z.PhoneNumber == model.PhoneNumber);
            if (user == null)
                return new ServiceResult(false, ApiResultStatusCode.NotFound);
            user.Type = type;
            user.ValidCode = new CreateRandom().RandomNumber4().ToString();
            user.ValidCodeExpired = DateTime.Now.AddMinutes(_siteSettings.ValidCodeExpired);
            await sendSmsValidCode(user.PhoneNumber, user.ValidCode);
            await _uow.SaveChangesAsync();
            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> EditEmailAddress(string username, string emailAddress)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), username, username, emailAddress);
            var user = await _user.FirstOrDefaultAsync(u => u.UserName == username);

            if (user.UserName == user.Email)
            {
                user.UserName = emailAddress;
            }
            user.Email = emailAddress ?? "";

            var newUserDto = new UserEditDto
            {
                Id = user.Id,
                Age = user.Age,
                FullName = user.FullName,
                Gender = user.Gender,
                IsPerson = user.IsPerson,
                NikName = user.NikName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                UserName = user.UserName
            };
            await Update(user.Id, newUserDto, new CancellationToken());
            await _uow.SaveChangesAsync();

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }
    }
}