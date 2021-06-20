using BusinessBaseConfig.Configuration.Queries;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.GetAllAsync
{
    public class GetAllAsyncQueryHandler : IQueryHandler<GetAllAsyncQuery, ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<GetAllAsyncQueryHandler> _logger;

        public GetAllAsyncQueryHandler(ILogger<GetAllAsyncQueryHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>> Handle(GetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}