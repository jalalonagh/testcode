using BusinessLayout.Configuration.Queries;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryHandler : IQueryHandler<GetByIdAsyncQuery, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<GetByIdAsyncQueryHandler> _logger;

        public GetByIdAsyncQueryHandler(ILogger<GetByIdAsyncQueryHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(GetByIdAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetByIdAsync(request.EntityIds);
        }
    }
}