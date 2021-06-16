using BusinessLayout.Configuration.Queries;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryHandler : IQueryHandler<SearchRangeAsyncQuery, ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<SearchRangeAsyncQueryHandler> _logger;

        public SearchRangeAsyncQueryHandler(ILogger<SearchRangeAsyncQueryHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>> Handle(SearchRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.SearchRangeAsync(request.Model);
        }
    }
}