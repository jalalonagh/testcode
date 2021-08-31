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
    public class GenericController<TEntity, TValid, TSearch, TVM, TDTO, TKey> : BaseController
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearch : BaseSearchEntity, new()
        where TVM : BaseVM<TVM, TEntity, TKey>, new()
        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
        where TKey : struct
    {
        private ICrud<TEntity, TValid, TSearch, TDTO, TKey> crud;
        ResourceManagerSingleton resource;

        public GenericController(ICrud<TEntity, TValid, TSearch, TDTO, TKey> _crud)
        {
            crud = _crud;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<IApiResult<TVM>> AddAsync(TDTO model, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.AddAsync(model.MapTo<TEntity>(), validator);
            var entity = result.MapTo<ServiceResult<TEntity>>();
            return entity.ToApiResult<TEntity, TDTO, TVM, TKey>();
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
        public async Task<IApiResult<TVM>> DeleteAsync(TDTO model, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteAsync(model.MapTo<TEntity>(), validator);
            var entity = result.MapTo<ServiceResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<TVM>> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteByIdAsync(id);
            var entity = resource.MapTo<ServiceResult<TVM>>();
            return entity.ToApiResult();
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
        public async Task<IApiResult<TVM>> UpdateAsync(TDTO model, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateAsync(model.MapTo<TEntity>(), validator);
            var entity = result.MapTo<ServiceResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<TVM>> UpdateFieldRangeAsync(TDTO model, string fields, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateFieldRangeAsync(model.MapTo<TEntity>(), validator, fields);
            var entity = result.MapTo<ServiceResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<TVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateFieldRangeByIdAsync(id, fields);
            var entity = result.MapTo<ServiceResult<TVM>>();
            return entity.ToApiResult();
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
        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> FilterRangeAsync(FilterRangeModel<TSearch> model)
        {
            var result = await crud.FilterRangeAsync(model);
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
        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> SearchRangeAsync(SearchRangeModel<TEntity> model)
        {
            var result = await crud.SearchRangeAsync(model);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpPost("[action]")]
        public async Task<IApiResult<TVM>> GetByIdAsync(int[] ids)
        {
            var result = await crud.GetByIdAsync(ids);
            var entity = result.MapTo<ServiceResult<TVM>>();
            return entity.ToApiResult();
        }
    }
}