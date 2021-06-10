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
    public class GetAllAsyncQueryHandler : IQueryHandler<GetAllAsyncQuery, ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<GetAllAsyncQueryHandler> _logger;

        public GetAllAsyncQueryHandler(ILogger<GetAllAsyncQueryHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Phone.Phone>>> Handle(GetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}