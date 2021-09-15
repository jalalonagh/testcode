using Common;
using Data.Repositories.Models;
using ManaBaseEntity.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManaBaseData.Repositories
{
    public interface IRangeRepository<TEntity> : IScopedDependency
        where TEntity : class, IEntity
    {

        DbContext Database { get; }
        DbSet<TEntity> Entities { get; }

        Task<RepositoryResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<RepositoryResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
