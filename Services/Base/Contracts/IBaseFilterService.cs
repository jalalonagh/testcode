using ManaBaseData.Repositories;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IBaseFilterService<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        IFilterRepository<TEntity, TSearchEntity> repository { get; }

        Task<ServiceResult> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<ServiceResult> SearchRangeAsync(SearchRangeModel<TEntity> search);
        Task<ServiceResult> ItemSync(TEntity Target, TEntity Origin);
    }
}
