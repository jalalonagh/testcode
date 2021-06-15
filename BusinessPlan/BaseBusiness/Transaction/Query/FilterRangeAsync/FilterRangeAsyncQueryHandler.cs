using BusinessLayout.Configuration.Queries;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryHandler : IQueryHandler<FilterRangeAsyncQuery, ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<FilterRangeAsyncQueryHandler> _logger;

        public FilterRangeAsyncQueryHandler(ILogger<FilterRangeAsyncQueryHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>> Handle(FilterRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.FilterRangeAsync(request.Model);
        }
    }
}