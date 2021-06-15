using BusinessLayout.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandHandler : ICommandHandler<UpdateFieldRangeAsyncCommand, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<UpdateFieldRangeAsyncCommandHandler> _logger;

        public UpdateFieldRangeAsyncCommandHandler(ILogger<UpdateFieldRangeAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(UpdateFieldRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeAsync(request.Model.ToEntity(), request.Fields);
        }
    }
}