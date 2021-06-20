using BusinessBaseConfig.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandHandler : ICommandHandler<UpdateFieldRangeByIdAsyncCommand, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<UpdateFieldRangeByIdAsyncCommandHandler> _logger;

        public UpdateFieldRangeByIdAsyncCommandHandler(ILogger<UpdateFieldRangeByIdAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(UpdateFieldRangeByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeByIdAsync(request.EntityId, request.Fields);
        }
    }
}