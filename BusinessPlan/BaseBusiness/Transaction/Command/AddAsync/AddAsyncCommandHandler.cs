using BusinessLayout.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.AddAsync
{
    public class AddAsyncCommandHandler : ICommandHandler<AddAsyncCommand, ServiceResult<Entities.Transaction.Transaction>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<AddAsyncCommandHandler> _logger;

        public AddAsyncCommandHandler(ILogger<AddAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Transaction.Transaction>> Handle(AddAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddAsync(request.Model.ToEntity());
        }
    }
}