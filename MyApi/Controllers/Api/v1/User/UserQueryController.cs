using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class UserQueryController : BaseController
    {
        private readonly ILogger<UserQueryController> _logger;
        private IMediator mediator;

        public UserQueryController(ILogger<UserQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}