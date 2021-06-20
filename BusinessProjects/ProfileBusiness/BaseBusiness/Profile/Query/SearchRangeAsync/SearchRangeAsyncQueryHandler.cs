using BusinessBaseConfig.Configuration.Queries;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryHandler : IQueryHandler<SearchRangeAsyncQuery, ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<SearchRangeAsyncQueryHandler> _logger;

        public SearchRangeAsyncQueryHandler(ILogger<SearchRangeAsyncQueryHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Profile.Profile>>> Handle(SearchRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.SearchRangeAsync(request.Model);
        }
    }
}