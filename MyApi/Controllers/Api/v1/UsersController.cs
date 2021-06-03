//using Common;
//using Common.Exceptions;
//using Common.Resource;
//using Common.Utilities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using System;
//using System.Linq;
//using System.Reflection;
//using System.Resources;
//using System.Threading;
//using System.Threading.Tasks;
//using WebFramework.Api;

//namespace MyApi.Controllers.Api.v1
//{
//    [ApiVersion("1")]
//    public class UsersController : BaseController
//    {
//        private readonly ICustomerService _customerService;
//        private readonly IUserService _userService;
//        private readonly IProfileService _profileService;
//        private readonly SiteSettings _siteSettings;
//        private readonly SignalRSettings _signalSettings;
//        private readonly ILogger<UsersController> _logger;
//        private readonly ResourceManager _resourceManager;

//        public UsersController(IUserService userService,
//                               IProfileService profileService,
//                               IOptions<SiteSettings> siteSettings,
//                               IOptions<SignalRSettings> signalSettings,
//                               ILogger<UsersController> logger,
//                               ResourceManager resourceManager,
//                               ICustomerService customerService
//                               )
//        {
//            _customerService = customerService;
//            _userService = userService;
//            _profileService = profileService;
//            _siteSettings = siteSettings.Value;
//            _signalSettings = signalSettings.Value;
//            _logger = logger;
//            _resourceManager = resourceManager;
//        }

//        [HttpGet("{username}")]
//        public async Task<ApiResult<UserVM>> Get(string username, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, cancellationToken);
//            var result = await _userService.Get(username, cancellationToken);
//            if (result.IsSuccess)
//                return (UserVM)result.Data;

//            return new ApiResult<UserVM>(false, result.StatusCode, (UserVM)result.Data, result.Message);
//        }

//        [HttpPost("[action]")]
//        [AllowAnonymous]
//        public async Task<ApiResult<dto>> Token([FromForm] TokenRequest tokenRequest, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, tokenRequest, cancellationToken);

//            var result = await _userService.Token(tokenRequest, cancellationToken);

//            if (!result.IsSuccess)
//                return result.ToApiResult();

//            await _userService.SyncUser(tokenRequest, new Entities.User.User
//            {
//                Id = result.Data?.user?.Id ?? 0,
//                Email = result.Data?.user?.Email ?? "",
//                PhoneNumber = result.Data?.user?.PhoneNumber ?? string.Empty,
//                NikName = result.Data?.user?.NikName ?? "",
//                ValidCodeExpired = DateTime.Now.AddMinutes(_siteSettings.ValidCodeExpired),
//                Contacts = result.Data?.user?.Contacts?
//                    .Select(s =>
//                        new Entities.Contact
//                        {
//                            ContactTypeId = s.ContactTypeId,
//                            Value = s.Value
//                        })
//                    .ToList(),
//                IsPerson = true,
//                IsActive = true,
//                Age = result.Data?.user?.Age ?? 0,
//                Avatar = result.Data?.user?.Avatar ?? "",
//                FullName = result.Data?.user?.FullName ?? "",
//                Gender = result.Data?.user?.Gender ?? Entities.User.GenderType.Male,
//                UserType = result.Data?.user?.UserType ?? "",
//                UserName = tokenRequest.username,
//                SalcustSi = result.Data?.user?.SalcustSi ?? 0,
//                SalcustCu = result.Data?.user?.SalcustCu ?? "",
//                SalcustTp = result.Data?.user?.SalcustTp ?? ""
//            });

//            var addExist = await _profileService.AddIfExistProfile(tokenRequest.username, tokenRequest.username);

//            if (!addExist.IsSuccess)
//                return new ApiResult<dto>(false, ApiResultStatusCode.ServerError, null, _resourceManager.GetString(ResourceKey.FailedCheckProfile));
//            else
//            {
//                var message = new UserMessageModel(result.Data.user.Id, "ورود به سیستم", $"کاربری با نام  /{result.Data.user.FullName}/ به سیستم وارد شد", _signalSettings);
//                var messages = message.Create(_signalSettings, MODELTYPES.BOS, MODELTYPES.COP_APP_ORDER, MODELTYPES.COP_APP_PAYMENT);
//                var msg = new SignalRService();
//                await msg.SendMessage(messages);
//            }

//            var profile = await _profileService.GetProfile(result.Data.user.UserName);
//            result.Data.user.Profile = profile.Data;

//            return result.IsSuccess
//                ? new ApiResult<dto>(true, ApiResultStatusCode.Success, result.Data)
//                : new ApiResult<dto>(false, result.StatusCode, result.Data, result.Message);
//        }

//        [HttpPost("[action]")]
//        [AllowAnonymous]//TODO Authorize
//        public async Task<ApiResult<dto>> TokenWithUserId([FromForm] CustomerDto customerDto, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, customerDto, cancellationToken);


//            var user = await _userService.Get(customerDto.Id, cancellationToken);

//            if (user.Data == null)
//            {
//                var customer2 = await _customerService.Get(customerDto.Id);

//                var phoneNumber = customer2.CustomerCallNumbers.FirstOrDefault(x => x.Number.StartsWith("09")).Number;
//                if (string.IsNullOrEmpty(phoneNumber))
//                    throw new AppException(statusCode: ApiResultStatusCode.BadRequest, "شماره موبایلی برای ثبت نام مشتری یافت نکردم لطفا شماره موبایل های مشتری را چک کنید و باید شماره با '09' شروع شود. در غیر اینصورت شماره موبایل جدید از مشتری بگیرید و در لیست شماره موبایل های مشتری قرار دهید.");

//                var user2 = await CreatUser(new UserDto
//                {
//                    Password = "7654321",
//                    PhoneNumber = phoneNumber,
//                    UserName = phoneNumber,
//                    Gender = Entities.User.GenderType.Male,
//                    IsPerson = true,
//                    Age = 30,
//                    FullName = $"{customer2.FirstName ?? string.Empty} {customer2.LastName ?? string.Empty}",
//                    NikName = string.Empty,
//                    Email = $"{phoneNumber}@dinawin.com",
//                    SalcustTp = $"{customer2.FirstName ?? string.Empty} {customer2.LastName ?? string.Empty}",
//                    SalcustCu = customer2.Code,
//                    SalcustSi = customer2.ReferenceId
//                }, cancellationToken);

//                await CreateUserChair(user2.Data.Id, customer2.ChairId, cancellationToken);

//                user.Data = new Entities.User.User
//                {
//                    Id = user2.Data.Id,
//                    PhoneNumber = phoneNumber,
//                    UserName = phoneNumber,
//                    Gender = Entities.User.GenderType.Male,
//                    IsPerson = true,
//                    Age = 30,
//                    FullName = $"{customer2.FirstName ?? string.Empty} {customer2.LastName ?? string.Empty}",
//                    NikName = string.Empty,
//                    Email = $"{phoneNumber}@dinawin.com"
//                };
//            }

//            var tokenRequest = new TokenRequestUserId
//            {
//                userId = user?.Data?.Id ?? 0
//            };

//            var result = await _userService.Token(tokenRequest, cancellationToken);

//            if (!result.IsSuccess)
//                return result.ToApiResult();

//            await _userService.SyncUser(tokenRequest, new Entities.User.User
//            {
//                Id = result.Data?.user?.Id ?? 0,
//                Email = result.Data?.user?.Email ?? "",
//                PhoneNumber = result.Data?.user?.PhoneNumber ?? string.Empty,
//                NikName = result.Data?.user?.NikName ?? "",
//                ValidCodeExpired = DateTime.Now.AddMinutes(_siteSettings.ValidCodeExpired),
//                Contacts = result.Data?.user?.Contacts?
//                    .Select(s =>
//                        new Entities.Contact
//                        {
//                            ContactTypeId = s.ContactTypeId,
//                            Value = s.Value
//                        })
//                    .ToList(),
//                IsPerson = true,
//                IsActive = true,
//                Age = result.Data?.user?.Age ?? 0,
//                Avatar = result.Data?.user?.Avatar ?? "",
//                FullName = result.Data?.user?.FullName ?? "",
//                Gender = result.Data?.user?.Gender ?? Entities.User.GenderType.Male,
//                UserType = result.Data?.user?.UserType ?? "",
//                UserName = result.Data?.user?.UserName ?? "",
//                SalcustSi = result.Data?.user?.SalcustSi ?? 0,
//                SalcustCu = result.Data?.user?.SalcustCu ?? "",
//                SalcustTp = result.Data?.user?.SalcustTp ?? ""
//            });

//            var addExist = await _profileService.AddIfExistProfile(result.Data?.user?.UserName, result.Data?.user?.UserName);

//            if (!addExist.IsSuccess)
//                return new ApiResult<dto>(false, ApiResultStatusCode.ServerError, null, _resourceManager.GetString(ResourceKey.FailedCheckProfile));
//            else
//            {
//                var message = new UserMessageModel(result.Data.user.Id, "ورود به سیستم", $"کاربری با نام  /{result.Data.user.FullName}/ به سیستم وارد شد", _signalSettings);
//                var messages = message.Create(_signalSettings, MODELTYPES.BOS, MODELTYPES.COP_APP_ORDER, MODELTYPES.COP_APP_PAYMENT);
//                var msg = new SignalRService();
//                await msg.SendMessage(messages);
//            }


//            var profile = await _profileService.GetExextensionNumbers(Username);

//            if (profile.IsSuccess)
//                result.Data.ExtentionsNumber = profile.Data.ExtensionNumber;

//            return result.IsSuccess
//                ? new ApiResult<dto>(true, ApiResultStatusCode.Success, result.Data)
//                : new ApiResult<dto>(false, result.StatusCode, result.Data, result.Message);
//        }

//        [HttpPost("[action]")]
//        [AllowAnonymous]
//        public async Task<ApiResult<GoogleAccessToken>> GoogleToken([FromBody] GoogleSigninModel model, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);

//            var result = await _userService.GoogleToken(model, cancellationToken);

//            if (!result.IsSuccess)
//                return new ApiResult<GoogleAccessToken>(false, ApiResultStatusCode.ServerError, null, "توکن تولید نشد");

//            var userExist = await _userService.GetByEmail(model.Email, new CancellationToken());

//            if (userExist.IsSuccess)
//            {
//                var profileExist = await _profileService.AddIfExistProfile(userExist.Data.PhoneNumber, userExist.Data.UserName);

//                if (profileExist.IsSuccess)
//                    return new ApiResult<GoogleAccessToken>(true, ApiResultStatusCode.Success, result.Data, "");
//            }

//            return new ApiResult<GoogleAccessToken>(false, result.StatusCode, result.Data, result.Message);
//        }

//        private async Task<ApiResult<UserVM>> CreatUser(UserDto userDto, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userDto, cancellationToken);
//            var result = await _userService.Create(userDto, cancellationToken);
//            if (!result.IsSuccess)
//            {

//                return new ApiResult<UserVM>(false, result.StatusCode, (UserVM)result.Data, result.Message);
//            }
//            else
//            {
//                var message = new UserMessageModel(result.Data.Id, "ایجاد کاربر", $"کاربر جدیدی با نام  /{result.Data.FullName}/ در سیستم ثبت نام کرد", _signalSettings);
//                var messages = message.Create(_signalSettings, MODELTYPES.BOS, MODELTYPES.COP_APP_ORDER, MODELTYPES.COP_APP_PAYMENT);
//                var msg = new SignalRService();
//                await msg.SendMessage(messages);
//            }

//            await _profileService.AddProfile(userDto.PhoneNumber, userDto.UserName);
//            return (UserVM)result.Data;
//        }

//        private async Task<ApiResult> CreateUserChair(int userId, int? chairId, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userId, chairId, cancellationToken);

//            var result = await _userService.CreateUserChair(userId, chairId, cancellationToken);
//            return result.ToApiResult();
//        }

//        //[HttpPost("[action]")]
//        //public async Task<ApiResult> ValidPhone(string username, string code)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, code);
//        //    var result = await _userService.ValidPhone(username, code);
//        //    return result.ToApiResult();
//        //}

//        [HttpPut]
//        public async Task<ApiResult> Update(int id, UserEditDto user, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, id, user, cancellationToken);
//            var result = await _userService.Update(id, user, cancellationToken);
//            return result.ToApiResult();
//        }

//        [HttpDelete("[action]")]
//        [AllowAnonymous]
//        public async Task<ApiResult<string>> ResetPassword(string userName, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userName, cancellationToken);
//            await _profileService.AddIfExistProfile(userName, userName);
//            var result = await _userService.ResetPassword(userName, cancellationToken);
//            return result.ToApiResult();
//        }

//        [HttpDelete("[action]")]
//        public async Task<ApiResult> ChangeThePassword(string userName, string currentPassword, string newPassword, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, currentPassword, newPassword, cancellationToken);
//            var result = await _userService.ChangeThePassword(userName, currentPassword, newPassword, cancellationToken);
//            return result.ToApiResult();
//        }

//        [HttpGet("[action]")]
//        public async Task<ApiResult> AgainSendValidCode(string username, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, cancellationToken);
//            var result = await _userService.AgainSendValidCode(username, cancellationToken);
//            return result.ToApiResult();
//        }

//        [HttpPut("{username}")]
//        public async Task<ApiResult> Update(string username, IFormFile file, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username, file, cancellationToken);
//            var result = await _userService.Update(username, file, cancellationToken);
//            return result.ToApiResult();
//        }

//        //[AllowAnonymous]
//        //[HttpPost("[action]")]
//        //public async Task<ApiResult> SuspendedUser(SuspendedUserDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var user = await _userService.Get(model.PhoneNumber, cancellationToken);
//        //    if (user.Data != null)
//        //    {
//        //        return BadRequest(_resourceManager.GetString(ResourceKey.AlreadyUserWithThisMobilePhoneNumberExists));
//        //    }

//        //    var result = await _userService.RegisterSuspendedUser(model.ToEntity(), Entities.User.Type.CreateUser);
//        //    return result.ToApiResult();
//        //}

//        //[AllowAnonymous]
//        //[HttpPost("[action]")]
//        //public async Task<ApiResult> SuspendedUserResetPassword(SuspendedUserDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var result = await _userService.RegisterSuspendedUser(model.ToEntity(), Entities.User.Type.ResetPassword);
//        //    return result.ToApiResult();
//        //}

//        //[HttpPost("[action]")]
//        //[AllowAnonymous]
//        //public async Task<ApiResult> SuspendedUserVerify(SuspendedUserConfirmDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var result = await _userService.SuspendedUserVerify(model.ToEntity(), Entities.User.Type.CreateUser);
//        //    return result.ToApiResult();
//        //}

//        //[HttpPost("[action]")]
//        //[AllowAnonymous]
//        //public async Task<ApiResult> SuspendedUserVerifyResert(SuspendedUserConfirmDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var result = await _userService.SuspendedUserVerify(model.ToEntity(), Entities.User.Type.ResetPassword);
//        //    return result.ToApiResult();
//        //}

//        //[HttpPost("[action]")]
//        //[AllowAnonymous]
//        //public async Task<ApiResult> AgainSendValidCodeForSuspendedUser(SuspendedUserDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var result = await _userService.AgainSendValidCodeForSuspendedUser(model.ToEntity(), Entities.User.Type.CreateUser, cancellationToken);
//        //    return result.ToApiResult();
//        //}

//        //[HttpPost("[action]")]
//        //[AllowAnonymous]
//        //public async Task<ApiResult> AgainSendValidCodeForSuspendedUserResetPassword(SuspendedUserDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var result = await _userService.AgainSendValidCodeForSuspendedUser(model.ToEntity(), Entities.User.Type.ResetPassword, cancellationToken);
//        //    return result.ToApiResult();
//        //}

//        //[HttpPost("[action]")]
//        //[AllowAnonymous]
//        //public async Task<ApiResult> ResertPasswordByValidation(UserPasswordResertDTO model, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, model, cancellationToken);
//        //    var result = await _userService.ResetPasswordByValidation(model, cancellationToken);
//        //    return result.ToApiResult();
//        //}

//        //[HttpPost("[action]")]
//        //[AllowAnonymous]
//        //public async Task<ApiResult<UserVM>> CreateWithValidation(UserVerifiedDto userDto, CancellationToken cancellationToken)
//        //{
//        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, userDto, cancellationToken);
//        //    var user = new UserDto
//        //    {
//        //        Email = $"{userDto}@dinawin.com",
//        //        Age = 30,
//        //        FullName = "ورود اطلاعات کاربری",
//        //        IsPerson = true,
//        //        UserName = userDto.PhoneNumber,
//        //        PhoneNumber = userDto.PhoneNumber,
//        //        Password = userDto.Password,
//        //        UserType = "EndUser",
//        //        Gender = Entities.User.GenderType.Male
//        //    };
//        //    var result = await _userService.CreateWithValidation(user, cancellationToken);
//        //    if (!result.IsSuccess)
//        //    {
//        //        return new ApiResult<UserVM>(false, result.StatusCode, (UserVM)result.Data, result.Message);
//        //    }
//        //    else
//        //    {
//        //        var message = new UserMessageModel(result.Data?.Id ?? 0, "ایجاد کاربر", $"کاربر جدیدی با نام  /{result.Data?.FullName ?? ""}/ در سیستم ثبت نام کرد", _signalSettings);
//        //        var messages = message.Create(_signalSettings, MODELTYPES.BOS, MODELTYPES.COP_APP_ORDER, MODELTYPES.COP_APP_PAYMENT);
//        //        var msg = new SignalRService();
//        //        await msg.SendMessage(messages);
//        //    }

//        //    await _profileService.AddProfile(userDto.PhoneNumber, user.UserName);
//        //    return (UserVM)result.Data;
//        //}
//    }
//}