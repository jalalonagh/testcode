using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSQueryController : ControllerBase
    {
        private readonly ILogger<SMSQueryController> _logger;
        private IMediator mediator;

        public SMSQueryController(ILogger<SMSQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}