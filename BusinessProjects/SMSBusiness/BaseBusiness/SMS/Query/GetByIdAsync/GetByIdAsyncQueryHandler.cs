using BusinessBaseConfig.Configuration.Queries;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SMSBusiness.BaseBusinessLevel.SMS.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryHandler : IQueryHandler<GetByIdAsyncQuery, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<GetByIdAsyncQueryHandler> _logger;

        public GetByIdAsyncQueryHandler(ILogger<GetByIdAsyncQueryHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(GetByIdAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetByIdAsync(request.EntityIds);
        }
    }
}