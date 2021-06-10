using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class TransactionQueryController : BaseController
    {
        private readonly ILogger<TransactionQueryController> _logger;
        private IMediator mediator;

        public TransactionQueryController(ILogger<TransactionQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}