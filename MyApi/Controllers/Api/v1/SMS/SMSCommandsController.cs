using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSCommandsController : ControllerBase
    {
        private readonly ILogger<SMSCommandsController> _logger;
        private IMediator mediator;

        public SMSCommandsController(ILogger<SMSCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}