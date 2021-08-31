//using Entities.Profile;
//using ManaBaseData.Repositories.Models;
//using ManaDataTransferObject.Profile;
//using ManaViewModel.Profile;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WebFramework.Api;

//namespace MyApi.Controllers.Api.v1
//{
//    [ApiVersion("1")]
//    public class ProfileQueryController : BaseController
//    {
//        private readonly ILogger<ProfileQueryController> _logger;
//        private IMediator mediator;

//        public ProfileQueryController(ILogger<ProfileQueryController> logger, IMediator _mediator)
//        {
//            _logger = logger;
//            mediator = _mediator;
//        }

//        [HttpPost("[action]")]
//        public async Task<IApiResult<IEnumerable<ProfileVM>>> FilterRangeAsync(FilterRangeModel<ProfileSearch> model)
//        {
//            var result = await mediator.Send(new FilterRangeAsyncQuery(model));
//            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
//        }
//        [HttpGet("[action]")]
//        public async Task<IApiResult<IEnumerable<ProfileVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
//        {
//            var result = await mediator.Send(new ProfileGetAllAsyncQuery(total, more));
//            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
//        }
//        [HttpPost("[action]")]
//        public async Task<IApiResult<IEnumerable<ProfileVM>>> SearchRangeAsync(SearchRangeModel<Entities.Profile.Profile> model)
//        {
//            var result = await mediator.Send(new SearchRangeAsyncQuery(model));
//            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
//        }
//        [HttpPost("[action]")]
//        public async Task<IApiResult<ProfileVM>> GetByIdAsync(int[] ids)
//        {
//            var result = await mediator.Send(new GetByIdAsyncQuery(ids));
//            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
//        }
//    }
//}