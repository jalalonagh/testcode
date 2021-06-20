using BusinessBaseConfig.Configuration.Queries;
using Entities.SMSConfirmation;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryHandler : IQueryHandler<FilterRangeAsyncQuery, ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        private readonly IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> _service;
        private readonly ILogger<FilterRangeAsyncQueryHandler> _logger;

        public FilterRangeAsyncQueryHandler(ILogger<FilterRangeAsyncQueryHandler> logger, IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>> Handle(FilterRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.FilterRangeAsync(request.Model);
        }
    }
}