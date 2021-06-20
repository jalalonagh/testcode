using BusinessBaseConfig.Configuration.Queries;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Query.GetAllAsync
{
    public class ProfileGetAllAsyncQueryHandler : IQueryHandler<ProfileGetAllAsyncQuery, ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<ProfileGetAllAsyncQueryHandler> _logger;

        public ProfileGetAllAsyncQueryHandler(ILogger<ProfileGetAllAsyncQueryHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Profile.Profile>>> Handle(ProfileGetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}