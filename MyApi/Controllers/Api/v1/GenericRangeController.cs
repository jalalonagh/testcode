using BaseBusiness;
using BaseBusiness.Models;
using Common;
using FluentValidation;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaResourceManager;
using ManaViewModel.Common;
using Microsoft.AspNetCore.Mvc;
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
        private ICrudRange<TEntity, TValid> crud;
        ResourceManagerSingleton resource;

        public GenericRangeController(ICrudRange<TEntity, TValid> _crud)
        {
            crud = _crud;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<ApiResult> AddRangeAsync(IEnumerable<TDTO> models, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.AddRangeAsync(models.MapTo<IEnumerable<TEntity>>(), validator);
            var entities = result.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult> DeleteRangeAsync(IEnumerable<TDTO> models, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteRangeAsync(models.MapTo<IEnumerable<TEntity>>(), validator);
            var entities = result.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteRangeByIdsAsync(ids);
            var entities = resource.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult> UpdateRangeAsync(IEnumerable<TDTO> models, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateRangeAsync(models.MapTo<IEnumerable<TEntity>>(), validator);
            var entities = result.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpGet("[action]")]
        public async Task<ApiResult> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await crud.GetAllAsync(total, more);
            var entities = result.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
    }
}