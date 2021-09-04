using BaseBusiness.Models;
using Common;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaEntitiesValidation.Extensions;
using ManaResourceManager;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public class Filter<TEntity, TValid, TSearchEntity> : IFilter<TEntity, TValid, TSearchEntity>, IScopedDependency
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearchEntity : BaseSearchEntity, new()
    {
        public IBaseFilterService<TEntity, TSearchEntity> service { get; set; }
        ResourceManagerSingleton resource;
        public Filter(IBaseFilterService<TEntity, TSearchEntity> _service)
        {
            service = _service;
            resource = ResourceManagerSingleton.GetInstance();
        }

        public async Task<BusinessResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            if (filter == null)
                return false.GenerateBusinessResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.FilterRangeAsync(filter);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, TValid validator)
        {
            if (!Target.Validate(validator) || !Origin.Validate(validator))
                return false.GenerateBusinessResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.ItemSync(Target, Origin);
            return result.ToBusinessResult();
        }
        public async Task<BusinessResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            if (search == null)
                return false.GenerateBusinessResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            var result = await service.SearchRangeAsync(search);
            return result.ToBusinessResult();
        }
    }
}
