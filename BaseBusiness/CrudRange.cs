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

        public async Task<BusinessResult> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.AddRangeAsync(entities);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteRangeAsync(entities);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.DeleteRangeByIdsAsync(ids);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await service.GetAllAsync(total, more);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateBusinessResult(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.UpdateRangeAsync(entities);
            return result.ToBusinessResult();
        }
    }
}
