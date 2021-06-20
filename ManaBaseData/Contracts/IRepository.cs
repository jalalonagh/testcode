using Common;
using Data.Repositories.Models;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManaBaseData.Repositories
{
    public interface IRepository<TEntity, TSearchEntity> : IScopedDependency
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {

        DbContext Database { get; }
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<RepositoryResult<TEntity>> AddAsync(TEntity entity);
        Task<RepositoryResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<RepositoryResult<TEntity>> DeleteAsync(TEntity entity);
        Task<RepositoryResult<TEntity>> DeleteByIdAsync(int id);
        Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<RepositoryResult<TEntity>> GetByIdAsync(params object[] ids);
        Task<RepositoryResult<IEnumerable<TEntity>>> FetchByIdAsync(int id);
        Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<RepositoryResult<TEntity>> UpdateAsync(TEntity entity);
        Task<RepositoryResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task<RepositoryResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<RepositoryResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
        Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
