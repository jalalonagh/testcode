using BusinessLayout.Configuration.Commands;
using Entities.Transaction;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandHandler : ICommandHandler<UpdateRangeAsyncCommand, ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        private readonly IBaseService<Entities.Transaction.Transaction, TransactionSearch> _service;
        private readonly ILogger<UpdateRangeAsyncCommandHandler> _logger;

        public UpdateRangeAsyncCommandHandler(ILogger<UpdateRangeAsyncCommandHandler> logger, IBaseService<Entities.Transaction.Transaction, TransactionSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>> Handle(UpdateRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}