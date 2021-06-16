using BusinessLayout.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateAsync
{
    public class UpdateAsyncCommandHandler : ICommandHandler<UpdateAsyncCommand, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<UpdateAsyncCommandHandler> _logger;

        public UpdateAsyncCommandHandler(ILogger<UpdateAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(UpdateAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateAsync(request.Model.ToEntity());
        }
    }
}