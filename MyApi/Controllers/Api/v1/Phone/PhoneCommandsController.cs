using Entities.Phone;
using ManaDataTransferObject.Phone;
using ManaResourceManager;
using ManaViewModel.Phone;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneCommandsController : BaseController
    {
        private readonly ILogger<PhoneCommandsController> _logger;
        private IMediator mediator;
        ResourceManagerSingleton resource;

        public PhoneCommandsController(ILogger<PhoneCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
            resource = ResourceManagerSingleton.Instance;
        }

        #region POST
        [HttpPost("[action]")]
        public async Task<ApiResult<PhoneVM>> AddAsync(PhoneDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(model));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> AddRangeAsync(IEnumerable<PhoneDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddRangeAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(models));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        #endregion
        #region DELETE
        [HttpDelete("[action]")]
        public async Task<ApiResult<PhoneVM>> DeleteAsync(PhoneDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(model));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<PhoneVM>> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteByIdAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(id));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> DeleteRangeAsync(IEnumerable<PhoneDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(models));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(ids));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        #endregion
        #region PUT
        [HttpPut("[action]")]
        public async Task<ApiResult<PhoneVM>> UpdateAsync(PhoneDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(model));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<PhoneVM>> UpdateFieldRangeAsync(PhoneDTO model, string fields)
        {
            if (!ModelState.IsValid)
                return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(model, fields.Split(",")));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<PhoneVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(id, fields));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> UpdateRangeAsync(IEnumerable<PhoneDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateRangeAsyncCommand<Entities.Phone.Phone, PhoneDTO, PhoneSearch, int>(models));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        #endregion

    }
}