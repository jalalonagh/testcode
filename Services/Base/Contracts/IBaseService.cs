using ManaBaseData.Repositories;
using ManaBaseEntity.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IBaseService<TEntity>
        where TEntity : class, IEntity
    {
        IRepository<TEntity> repository { get; }

        Task<IServiceResult<TEntity>> AddAsync(TEntity entity);
        Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity);
        Task<IServiceResult<TEntity>> DeleteByIdAsync(int id);
        Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids);
        Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity);
        Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
