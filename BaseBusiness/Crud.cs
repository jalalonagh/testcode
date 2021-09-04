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

        public async Task<BusinessResult<TEntity>> AddAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.AddAsync(entity);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> DeleteAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteAsync(entity);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> DeleteByIdAsync(int id)
        {
            if (id <= 0)
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteByIdAsync(id);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            if (ids == null || !ids.Any())
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.GetByIdAsync(ids);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> UpdateAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateAsync(entity);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields)
        {
            if (!entity.Validate(validator) || fields == null || !fields.Any())
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateFieldRangeAsync(entity, fields);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            if (Id <= 0 || fields == null || !fields.Any())
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateFieldRangeByIdAsync(Id, fields);
            return result.ToBusinessResult();
        }
    }
}
