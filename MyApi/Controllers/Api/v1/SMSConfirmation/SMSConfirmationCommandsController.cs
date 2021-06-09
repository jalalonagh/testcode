using Entities.SMSConfirmation;
using ManaDataTransferObject.SMSConfirmation;
using ManaViewModel.SMSConfirmation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSConfirmationCommandsController : BaseBusinessCommandController<SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, SMSConfirmationSearch, int>
    {
        private readonly ILogger<SMSConfirmationCommandsController> _logger;
        private IMediator mediator;

        public SMSConfirmationCommandsController(ILogger<SMSConfirmationCommandsController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}