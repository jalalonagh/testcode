using Entities.Transaction;
using ManaDataTransferObject.Transaction;
using ManaViewModel.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class TransactionCommandsController : BaseBusinessCommandController<Transaction, TransactionDTO, TransactionVM, TransactionSearch, int>
    {
        private readonly ILogger<TransactionCommandsController> _logger;
        private IMediator mediator;

        public TransactionCommandsController(ILogger<TransactionCommandsController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}