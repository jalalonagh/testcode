using BusinessBaseConfig.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.DeleteAsync
{
    public class DeleteAsyncCommandHandler : ICommandHandler<DeleteAsyncCommand, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<DeleteAsyncCommandHandler> _logger;

        public DeleteAsyncCommandHandler(ILogger<DeleteAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(DeleteAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteAsync(request.Model.ToEntity());
        }
    }
}