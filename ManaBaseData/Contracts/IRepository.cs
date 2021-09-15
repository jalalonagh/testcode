using Common;
using Data.Repositories.Models;
using ManaBaseEntity.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManaBaseData.Repositories
{
    public interface IRepository<TEntity> : IScopedDependency
        where TEntity : class, IEntity
    {

        DbContext Database { get; }
        DbSet<TEntity> Entities { get; }

        Task<RepositoryResult<TEntity>> AddAsync(TEntity entity);
        Task<RepositoryResult<TEntity>> DeleteAsync(TEntity entity);
        Task<RepositoryResult<TEntity>> DeleteByIdAsync(int id);
        Task<RepositoryResult<TEntity>> GetByIdAsync(params object[] ids);
        Task<RepositoryResult<IEnumerable<TEntity>>> FetchByIdAsync(int id);
        Task<RepositoryResult<TEntity>> UpdateAsync(TEntity entity);
        Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
        RepositoryResult<TEntity> Detach(TEntity entity);
        RepositoryResult<TEntity> Attach(TEntity entity);
    }
}
