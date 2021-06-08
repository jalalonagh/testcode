
using Entities.Profile;
using ManaDataTransferObject.Profile;
using ManaViewModel.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class ProfileQueryController : BaseBusinessCommandController<Profile, ProfileDTO, ProfileVM, ProfileSearch, int>
    {
        private readonly ILogger<ProfileQueryController> _logger;
        private IMediator mediator;

        public ProfileQueryController(ILogger<ProfileQueryController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}