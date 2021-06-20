using BusinessBaseConfig.Configuration.Queries;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryHandler : IQueryHandler<SearchRangeAsyncQuery, ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<SearchRangeAsyncQueryHandler> _logger;

        public SearchRangeAsyncQueryHandler(ILogger<SearchRangeAsyncQueryHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>> Handle(SearchRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.SearchRangeAsync(request.Model);
        }
    }
}