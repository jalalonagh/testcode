using Entities.SMS;
using ManaDataTransferObject.SMS;
using ManaViewModel.SMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSCommandsController : BaseBusinessCommandController<SMS, SMSDTO, SMSVM, SMSSearch, int>
    {
        private readonly ILogger<SMSCommandsController> _logger;
        private IMediator mediator;

        public SMSCommandsController(ILogger<SMSCommandsController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}