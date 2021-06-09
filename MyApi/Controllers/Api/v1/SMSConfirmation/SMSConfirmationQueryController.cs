
using Entities.SMSConfirmation;
using ManaDataTransferObject.SMSConfirmation;
using ManaViewModel.SMSConfirmation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSConfirmationQueryController : BaseBusinessQueryController<SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, SMSConfirmationSearch, int>
    {
        private readonly ILogger<SMSConfirmationQueryController> _logger;
        private IMediator mediator;

        public SMSConfirmationQueryController(ILogger<SMSConfirmationQueryController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}