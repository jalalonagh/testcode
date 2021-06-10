using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class ConfirmedTransactionQueryController : BaseController
    {
        private readonly ILogger<ConfirmedTransactionQueryController> _logger;
        private IMediator mediator;

        public ConfirmedTransactionQueryController(ILogger<ConfirmedTransactionQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}