using BaseBusiness;
using Common;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaResourceManager;
using ManaViewModel.Common;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    //[ApiVersion("1")]
    public class GenericRangeController<TEntity, TValid, TVM, TDTO> : BaseController
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TVM : BaseVM<TVM, TEntity, int>, new()
        where TDTO : BaseDTO<TDTO, TEntity, int>, new()
    {
        private ICrudRange<TEntity, TValid, TDTO> crud;
        ResourceManagerSingleton resource;

        public GenericRangeController(ICrudRange<TEntity, TValid, TDTO> _crud)
        {
            crud = _crud;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> AddRangeAsync(IEnumerable<TDTO> models, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.AddRangeAsync(models.MapTo<IEnumerable<TEntity>>(), validator);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> DeleteRangeAsync(IEnumerable<TDTO> models, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteRangeAsync(models.MapTo<IEnumerable<TEntity>>(), validator);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteRangeByIdsAsync(ids);
            var entities = resource.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> UpdateRangeAsync(IEnumerable<TDTO> models, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateRangeAsync(models.MapTo<IEnumerable<TEntity>>(), validator);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpGet("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await crud.GetAllAsync(total, more);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
    }
}