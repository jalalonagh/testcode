using BusinessBaseConfig.Configuration.Queries;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMSBusiness.BaseBusinessLevel.SMS.Query.GetAllAsync
{
    public class SMSGetAllAsyncQueryHandler : IQueryHandler<SMSGetAllAsyncQuery, ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<SMSGetAllAsyncQueryHandler> _logger;

        public SMSGetAllAsyncQueryHandler(ILogger<SMSGetAllAsyncQueryHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMS.SMS>>> Handle(SMSGetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}