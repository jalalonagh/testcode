using BusinessBaseConfig.Configuration.Queries;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Query.GetAllAsync
{
    public class GetAllAsyncQueryHandler : IQueryHandler<GetAllAsyncQuery, ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<GetAllAsyncQueryHandler> _logger;

        public GetAllAsyncQueryHandler(ILogger<GetAllAsyncQueryHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>> Handle(GetAllAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetAllAsync(request.Total, request.More);
        }
    }
}