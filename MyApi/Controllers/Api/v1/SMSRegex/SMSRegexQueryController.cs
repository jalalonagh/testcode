using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSRegexQueryController : BaseController
    {
        private readonly ILogger<SMSRegexQueryController> _logger;
        private IMediator mediator;

        public SMSRegexQueryController(ILogger<SMSRegexQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}