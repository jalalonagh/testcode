using ManaDataTransferObject.Profile;
using ManaResourceManager;
using ManaViewModel.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.AddAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.AddRangeAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.DeleteAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.DeleteByIdAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.DeleteRangeAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.DeleteRangeByIdsAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.UpdateAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.UpdateFieldRangeAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.UpdateFieldRangeByIdAsync;
using ProfileBusiness.BaseBusinessLevel.Profile.Command.UpdateRangeAsync;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class ProfileCommandsController : BaseController
    {
        private readonly ILogger<ProfileCommandsController> _logger;
        private IMediator mediator;
        ResourceManagerSingleton resource;

        public ProfileCommandsController(ILogger<ProfileCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
            resource = ResourceManagerSingleton.GetInstance();
        }

        #region POST
        [HttpPost("[action]")]
        public async Task<ApiResult<ProfileVM>> AddAsync(ProfileDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<ProfileVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddAsyncCommand(model));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<ProfileVM>>> AddRangeAsync(IEnumerable<ProfileDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<ProfileVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddRangeAsyncCommand(models));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        #endregion
        #region DELETE
        [HttpDelete("[action]")]
        public async Task<ApiResult<ProfileVM>> DeleteAsync(ProfileDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<ProfileVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteAsyncCommand(model));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<ProfileVM>> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ApiResult<ProfileVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteByIdAsyncCommand(id));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<IEnumerable<ProfileVM>>> DeleteRangeAsync(IEnumerable<ProfileDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<ProfileVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeAsyncCommand(models));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<IEnumerable<ProfileVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<ProfileVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand(ids));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        #endregion
        #region PUT
        [HttpPut("[action]")]
        public async Task<ApiResult<ProfileVM>> UpdateAsync(ProfileDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<ProfileVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateAsyncCommand(model));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<ProfileVM>> UpdateFieldRangeAsync(ProfileDTO model, string fields)
        {
            if (!ModelState.IsValid)
                return new ApiResult<ProfileVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand(model, fields.Split(",")));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<ProfileVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return new ApiResult<ProfileVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand(id, fields));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<IEnumerable<ProfileVM>>> UpdateRangeAsync(IEnumerable<ProfileDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<ProfileVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateRangeAsyncCommand(models));
            return result.ToApiResult<Entities.Profile.Profile, ProfileDTO, ProfileVM, int>();
        }
        #endregion
    }
}