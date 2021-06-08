using BusinessLayout.Cart.Command.AddAsync;
using BusinessLayout.Cart.Command.AddRangeAsync;
using BusinessLayout.Cart.Command.DeleteAsync;
using BusinessLayout.Cart.Command.DeleteByIdAsync;
using BusinessLayout.Cart.Command.DeleteRangeAsync;
using BusinessLayout.Cart.Command.DeleteRangeByIdsAsync;
using BusinessLayout.Cart.Command.UpdateAsync;
using BusinessLayout.Cart.Command.UpdateFieldRangeAsync;
using BusinessLayout.Cart.Command.UpdateFieldRangeByIdAsync;
using BusinessLayout.Cart.Command.UpdateRangeAsync;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using ManaDataTransferObject.Common;
using ManaResourceManager;
using ManaViewModel.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class BaseBusinessCommandController<TEntity, TDTO, TVM, TSearch, TKey> : BaseController
        where TEntity : BaseEntity, new()
        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
        where TVM : BaseVM<TVM, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private IMediator mediator;
        ResourceManagerSingleton resource;

        public BaseBusinessCommandController(IMediator _mediator)
        {
            mediator = _mediator;
            resource = ResourceManagerSingleton.Instance;
        }

        #region POST
        [HttpPost("[action]")]
        public async Task<ApiResult<TVM>> AddAsync(TDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<TVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddAsyncCommand<TEntity, TDTO, TSearch, TKey>(model));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> AddRangeAsync(IEnumerable<TDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<TVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>(models));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        #endregion
        #region DELETE
        [HttpDelete("[action]")]
        public async Task<ApiResult<TVM>> DeleteAsync(TDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<TVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteAsyncCommand<TEntity, TDTO, TSearch, TKey>(model));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<TVM>> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ApiResult<TVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>(id));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> DeleteRangeAsync(IEnumerable<TDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<TVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>(models));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<TVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand<TEntity, TDTO, TSearch, TKey>(ids));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        #endregion
        #region PUT
        [HttpPut("[action]")]
        public async Task<ApiResult<TVM>> UpdateAsync(TDTO model)
        {
            if (!ModelState.IsValid)
                return new ApiResult<TVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateAsyncCommand<TEntity, TDTO, TSearch, TKey>(model));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<TVM>> UpdateFieldRangeAsync(TDTO model, string[] fields)
        {
            if (!ModelState.IsValid)
                return new ApiResult<TVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>(model, fields));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<TVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return new ApiResult<TVM>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>(id, fields));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> UpdateRangeAsync(IEnumerable<TDTO> models)
        {
            if (!ModelState.IsValid)
                return new ApiResult<IEnumerable<TVM>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>(models));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
        #endregion
    }
}