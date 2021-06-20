using BusinessBaseConfig.Configuration.Queries;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryHandler : IQueryHandler<FilterRangeAsyncQuery, ServiceResult<IEnumerable<Entities.User.User>>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<FilterRangeAsyncQueryHandler> _logger;

        public FilterRangeAsyncQueryHandler(ILogger<FilterRangeAsyncQueryHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.User.User>>> Handle(FilterRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.FilterRangeAsync(request.Model);
        }
    }
}