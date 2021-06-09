
using Entities.Transaction;
using ManaDataTransferObject.Transaction;
using ManaViewModel.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class TransactionQueryController : BaseBusinessQueryController<Transaction, TransactionDTO, TransactionVM, TransactionSearch, int>
    {
        private readonly ILogger<TransactionQueryController> _logger;
        private IMediator mediator;

        public TransactionQueryController(ILogger<TransactionQueryController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}