using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class ConfirmedTransactionCommandsController : BaseController
    {
        private readonly ILogger<ConfirmedTransactionCommandsController> _logger;
        private IMediator mediator;

        public ConfirmedTransactionCommandsController(ILogger<ConfirmedTransactionCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}