using BusinessLayout.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandHandler : ICommandHandler<AddRangeAsyncCommand, ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<AddRangeAsyncCommandHandler> _logger;

        public AddRangeAsyncCommandHandler(ILogger<AddRangeAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>> Handle(AddRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}