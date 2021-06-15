using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
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

        [HttpGet("[action]")]
        public async Task<ApiResult> AgainSendValidCode(string username, CancellationToken cancellationToken)
        {
            var result = await _userService.AgainSendValidCode(username, cancellationToken);
            return result.ToApiResult();
        }
    }
}