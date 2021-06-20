using BusinessBaseConfig.Configuration.Queries;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryHandler : IQueryHandler<FilterRangeAsyncQuery, ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<FilterRangeAsyncQueryHandler> _logger;

        public FilterRangeAsyncQueryHandler(ILogger<FilterRangeAsyncQueryHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Profile.Profile>>> Handle(FilterRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.FilterRangeAsync(request.Model);
        }
    }
}