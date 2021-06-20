using BusinessBaseConfig.Configuration.Queries;
using Entities.SMSConfirmation;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Query.GetAllAsync
{
    public class GetAllAsyncQueryHandler : IQueryHandler<GetAllAsyncQuery, ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        private readonly IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> _service;
        private readonly ILogger<GetAllAsyncQueryHandler> _logger;

        public GetAllAsyncQueryHandler(ILogger<GetAllAsyncQueryHandler> logger, IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>> Handle(GetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}