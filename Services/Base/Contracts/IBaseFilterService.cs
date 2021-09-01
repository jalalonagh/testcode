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

        Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
        Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin);
    }
}
