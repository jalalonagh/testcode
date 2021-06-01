using Common;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<TEntity, TSearchEntity> : IScopedDependency
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {

        DbContext Database { get; }
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> DeleteByIdAsync(int id);
        Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<TEntity> GetByIdAsync(params object[] ids);
        Task<IEnumerable<TEntity>> FetchByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<IEnumerable<TEntity>> SearchRangeAsync(SearchRangeModel<TEntity> search);
        Task<TEntity> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<TEntity> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
