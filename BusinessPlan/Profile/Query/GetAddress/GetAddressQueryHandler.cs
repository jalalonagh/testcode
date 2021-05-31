//using BusinessLayout.Configuration.Queries;
//using BusinessLayout.Profile.Share.ViewModels;
//using Common;
//using Common.Utilities;
//using Microsoft.Extensions.Logging;
//using Services;
//using Services.Profile;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BusinessLayout.Profile.Query.GetAddress
//{
//    public class GetAddressQueryHandler : IQueryHandler<GetAddressQuery, ServiceResult<IEnumerable<AddressVm>>>
//    {
//        private readonly IProfileService _profileService;
//        private readonly ILogger<GetAddressQueryHandler> _logger;

//        public GetAddressQueryHandler(IProfileService profileService, ILogger<GetAddressQueryHandler> logger)
//        {
//            _profileService = profileService;
//            _logger = logger;
//        }

//        public async Task<ServiceResult<IEnumerable<AddressVm>>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, request, cancellationToken);
//            var resultAddress = await _profileService.GetAddress(request.Username);

//            if (!resultAddress.IsSuccess)
//            {
//                return new ServiceResult<IEnumerable<AddressVm>>(false, ApiResultStatusCode.NotFound, null);

//            }
//            var result = resultAddress.Data.Select(AddressVm.FromEntity);
//            return new ServiceResult<IEnumerable<AddressVm>>(true, ApiResultStatusCode.Success, result);
//        }
//    }
//}