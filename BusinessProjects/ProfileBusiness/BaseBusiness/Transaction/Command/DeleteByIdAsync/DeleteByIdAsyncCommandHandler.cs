using BusinessLayout.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandHandler : ICommandHandler<DeleteByIdAsyncCommand, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<DeleteByIdAsyncCommandHandler> _logger;

        public DeleteByIdAsyncCommandHandler(ILogger<DeleteByIdAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(DeleteByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteByIdAsync(request.EntityId);
        }
    }
}