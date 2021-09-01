using Common;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaEntitiesValidation.Extensions;
using ManaResourceManager;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            if (filter == null)
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.FilterRangeAsync(filter);
        }
        public async Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, TValid validator)
        {
            if (!Target.Validate(validator) || !Origin.Validate(validator))
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.ItemSync(Target, Origin);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            if (search == null)
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.SearchRangeAsync(search);
        }
    }
}
