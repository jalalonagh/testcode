using BusinessLayout.Configuration.Queries;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Query.GetAllAsync
{
    public class GetAllAsyncQueryHandler : IQueryHandler<GetAllAsyncQuery, ServiceResult<IEnumerable<Entities.User.User>>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<GetAllAsyncQueryHandler> _logger;

        public GetAllAsyncQueryHandler(ILogger<GetAllAsyncQueryHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.User.User>>> Handle(GetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}