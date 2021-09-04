using BaseBusiness.Models;
using Common;
using FluentValidation;
using ManaBaseEntity.Common;
using ManaEntitiesValidation.Extensions;
using ManaResourceManager;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public class Crud<TEntity, TValid> : ICrud<TEntity, TValid>, IScopedDependency
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
    {
        public IBaseService<TEntity> service { get; set; }
        ResourceManagerSingleton resource;
        public Crud(IBaseService<TEntity> _service)
        {
            service = _service;
            resource = ResourceManagerSingleton.GetInstance();
        }

        public async Task<BusinessResult> AddAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.AddAsync(entity);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> DeleteAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteAsync(entity);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> DeleteByIdAsync(int id)
        {
            if (id <= 0)
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteByIdAsync(id);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> GetByIdAsync(params object[] ids)
        {
            if (ids == null || !ids.Any())
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.GetByIdAsync(ids);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> UpdateAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateAsync(entity);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields)
        {
            if (!entity.Validate(validator) || fields == null || !fields.Any())
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateFieldRangeAsync(entity, fields);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            if (Id <= 0 || fields == null || !fields.Any())
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateFieldRangeByIdAsync(Id, fields);
            return result.ToBusinessResult();
        }
    }
}
