using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class TransactionCommandsController : BaseController
    {
        private readonly ILogger<TransactionCommandsController> _logger;
        private IMediator mediator;

        public TransactionCommandsController(ILogger<TransactionCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}