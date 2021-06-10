using BusinessLayout.Configuration.Queries;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.GetAllAsync
{
    public class PhoneGetAllAsyncQueryHandler : IQueryHandler<PhoneGetAllAsyncQuery, ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<PhoneGetAllAsyncQueryHandler> _logger;

        public PhoneGetAllAsyncQueryHandler(ILogger<PhoneGetAllAsyncQueryHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Phone.Phone>>> Handle(PhoneGetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}