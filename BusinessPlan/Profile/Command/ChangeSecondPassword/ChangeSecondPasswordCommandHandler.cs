//using BusinessLayout.Configuration.Commands;
//using BusinessLayout.Profile.Share.ViewModels;
//using Common;
//using Common.FileManager;
//using Common.Resource;
//using Common.Utilities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using Services;
//using Services.File;
//using Services.PhoneNumber;
//using Services.Profile;
//using System.Drawing;
//using System.IO;
//using System.Reflection;
//using System.Resources;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BusinessLayout.Profile.Command.ChangeSecondPassword
//{
//    public class ChangeSecondPasswordCommandHandler : ICommandHandler<ChangeSecondPasswordCommand, ServiceResult>
//    {
//        private readonly IProfileService _profileService;
//        private readonly IFileService _fileService;
//        private readonly IUserService _userService;
//        private readonly IPhoneNumberService _phoneNumberService;
//        private readonly ResourceManager _resourceManager;
//        private readonly ILogger<ChangeSecondPasswordCommandHandler> _logger;

//        public ChangeSecondPasswordCommandHandler(IProfileService profileService,
//                                                     IFileService fileService,
//                                                     IUserService userService,
//                                                     IPhoneNumberService phoneNumberService,
//                                                     ResourceManager resourceManager,
//                                                     ILogger<ChangeSecondPasswordCommandHandler> logger)
//        {
//            _profileService = profileService;
//            _fileService = fileService;
//            _userService = userService;
//            _phoneNumberService = phoneNumberService;
//            _resourceManager = resourceManager;
//            _logger = logger;
//        }

//        public async Task<ServiceResult> Handle(ChangeSecondPasswordCommand request, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, request, cancellationToken);

//            return await _profileService.ChangeSecondPassword(request.Password, request.NewPassword, request.Username);
//        }
//    }
//}