using BusinessLayout.Configuration.Queries;
using Entities.SMSConfirmation;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryHandler : IQueryHandler<SearchRangeAsyncQuery, ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        private readonly IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> _service;
        private readonly ILogger<SearchRangeAsyncQueryHandler> _logger;

        public SearchRangeAsyncQueryHandler(ILogger<SearchRangeAsyncQueryHandler> logger, IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>> Handle(SearchRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.SearchRangeAsync(request.Model);
        }
    }
}