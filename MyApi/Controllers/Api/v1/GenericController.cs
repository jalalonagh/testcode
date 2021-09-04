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
    public class GenericController<TEntity, TValid, TVM, TDTO> : BaseController
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TVM : BaseVM<TVM, TEntity, int>, new()
        where TDTO : BaseDTO<TDTO, TEntity, int>, new()
    {
        private ICrud<TEntity, TValid> crud;
        ResourceManagerSingleton resource;

        public GenericController(ICrud<TEntity, TValid> _crud)
        {
            crud = _crud;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<ApiResult> AddAsync(TDTO model, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.AddAsync(model.MapTo<TEntity>(), validator);
            var entity = result.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult> DeleteAsync(TDTO model, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteAsync(model.MapTo<TEntity>(), validator);
            var entity = result.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpDelete("[action]")]
        public async Task<ApiResult> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.DeleteByIdAsync(id);
            var entity = resource.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult> UpdateAsync(TDTO model, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateAsync(model.MapTo<TEntity>(), validator);
            var entity = result.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult> UpdateFieldRangeAsync(TDTO model, string fields, TValid validator)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateFieldRangeAsync(model.MapTo<TEntity>(), validator, fields);
            var entity = result.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpPut("[action]")]
        public async Task<ApiResult> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.UpdateFieldRangeByIdAsync(id, fields);
            var entity = result.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult> GetByIdAsync(int[] ids)
        {
            var result = await crud.GetByIdAsync(ids);
            var entity = result.MapTo<BusinessResult<TVM>>();
            return entity.ToApiResult();
        }
    }
}