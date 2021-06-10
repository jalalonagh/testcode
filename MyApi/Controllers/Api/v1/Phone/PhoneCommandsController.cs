using BusinessLayout.BaseBusinessLevel1.Phone.Command.AddAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.AddRangeAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteByIdAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteRangeAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteRangeByIdsAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateFieldRangeAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateFieldRangeByIdAsync;
using BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateRangeAsync;
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
            resource = ResourceManagerSingleton.GetInstance();
        }

        //#region POST
        //[HttpPost("[action]")]
        //public async Task<ApiResult<PhoneVM>> AddAsync(PhoneDTO model)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new AddAsyncCommand(model));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpPost("[action]")]
        //public async Task<ApiResult<IEnumerable<PhoneVM>>> AddRangeAsync(IEnumerable<PhoneDTO> models)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new AddRangeAsyncCommand(models));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //#endregion
        //#region DELETE
        //[HttpDelete("[action]")]
        //public async Task<ApiResult<PhoneVM>> DeleteAsync(PhoneDTO model)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new DeleteAsyncCommand(model));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpDelete("[action]")]
        //public async Task<ApiResult<PhoneVM>> DeleteByIdAsync(int id)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new DeleteByIdAsyncCommand(id));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpDelete("[action]")]
        //public async Task<ApiResult<IEnumerable<PhoneVM>>> DeleteRangeAsync(IEnumerable<PhoneDTO> models)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new DeleteRangeAsyncCommand(models));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpDelete("[action]")]
        //public async Task<ApiResult<IEnumerable<PhoneVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand(ids));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //#endregion
        //#region PUT
        //[HttpPut("[action]")]
        //public async Task<ApiResult<PhoneVM>> UpdateAsync(PhoneDTO model)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new UpdateAsyncCommand(model));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpPut("[action]")]
        //public async Task<ApiResult<PhoneVM>> UpdateFieldRangeAsync(PhoneDTO model, string fields)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new UpdateFieldRangeAsyncCommand(model, fields.Split(",")));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpPut("[action]")]
        //public async Task<ApiResult<PhoneVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<PhoneVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand(id, fields));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //[HttpPut("[action]")]
        //public async Task<ApiResult<IEnumerable<PhoneVM>>> UpdateRangeAsync(IEnumerable<PhoneDTO> models)
        //{
        //    if (!ModelState.IsValid)
        //        return new ApiResult<IEnumerable<PhoneVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await mediator.Send(new UpdateRangeAsyncCommand(models));
        //    return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        //}
        //#endregion
    }
}