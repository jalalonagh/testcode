using BaseBusiness.Models;
using Common;
using FluentValidation;
using ManaBaseEntity.Common;
using ManaEntitiesValidation.Extensions;
using ManaResourceManager;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public class CrudRange<TEntity, TValid> : ICrudRange<TEntity, TValid>, IScopedDependency
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
    {
        public IBaseRangeService<TEntity> service { get; set; }
        ResourceManagerSingleton resource;
        public CrudRange(IBaseRangeService<TEntity> _service)
        {
            service = _service;
            resource = ResourceManagerSingleton.GetInstance();
        }

        public async Task<IBusinessResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateBusinessResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.AddRangeAsync(entities);
            return result.ToBusinessResult();
        }
        public async Task<IBusinessResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateBusinessResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteRangeAsync(entities);
            return result.ToBusinessResult();
        }
        public async Task<IBusinessResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return false.GenerateBusinessResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteRangeByIdsAsync(ids);
            return result.ToBusinessResult();
        }
        public async Task<IBusinessResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await service.GetAllAsync(total, more);
            return result.ToBusinessResult();
        }
        public async Task<IBusinessResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateBusinessResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateRangeAsync(entities);
            return result.ToBusinessResult();
         }
    }
}
