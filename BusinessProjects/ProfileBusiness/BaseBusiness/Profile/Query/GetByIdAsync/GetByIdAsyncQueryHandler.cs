using BusinessBaseConfig.Configuration.Queries;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryHandler : IQueryHandler<GetByIdAsyncQuery, ServiceResult<Entities.Profile.Profile>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<GetByIdAsyncQueryHandler> _logger;

        public GetByIdAsyncQueryHandler(ILogger<GetByIdAsyncQueryHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Profile.Profile>> Handle(GetByIdAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetByIdAsync(request.EntityIds);
        }
    }
}