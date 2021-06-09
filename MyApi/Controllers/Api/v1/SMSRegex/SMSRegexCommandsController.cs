using Entities.SMSRegex;
using ManaDataTransferObject.SMSRegex;
using ManaViewModel.SMSRegex;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSRegexCommandsController : BaseBusinessCommandController<SMSRegex, SMSRegexDTO, SMSRegexVM, SMSRegexSearch, int>
    {
        private readonly ILogger<SMSRegexCommandsController> _logger;
        private IMediator mediator;

        public SMSRegexCommandsController(ILogger<SMSRegexCommandsController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}