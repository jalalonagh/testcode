using Entities.ConfirmedTransaction;
using ManaDataTransferObject.ConfirmedTransaction;
using ManaViewModel.ConfirmedTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class ConfirmedTransactionQueryController : BaseBusinessQueryController<ConfirmedTransaction, ConfirmedTransactionDTO, ConfirmedTransactionVM, ConfirmedTransactionSearch, int>
    {
        private readonly ILogger<ConfirmedTransactionQueryController> _logger;
        private IMediator mediator;

        public ConfirmedTransactionQueryController(ILogger<ConfirmedTransactionQueryController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}