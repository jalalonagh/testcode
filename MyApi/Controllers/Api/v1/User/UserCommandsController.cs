using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class UserCommandsController : BaseController
    {
        private readonly ILogger<UserCommandsController> _logger;
        private IMediator mediator;

        public UserCommandsController(ILogger<UserCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}