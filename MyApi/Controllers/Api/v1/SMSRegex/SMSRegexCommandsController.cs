using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSRegexCommandsController : BaseController
    {
        private readonly ILogger<SMSRegexCommandsController> _logger;
        private IMediator mediator;

        public SMSRegexCommandsController(ILogger<SMSRegexCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}