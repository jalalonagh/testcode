using Common;
using Data.Repositories.Models;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManaBaseData.Repositories
{
    public interface IFilterRepository<TEntity, TSearchEntity> : IScopedDependency
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {

        DbContext Database { get; }
        DbSet<TEntity> Entities { get; }

        Task<RepositoryResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<RepositoryResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
    }
}
