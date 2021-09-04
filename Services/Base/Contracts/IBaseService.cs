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

        Task<ServiceResult<TEntity>> AddAsync(TEntity entity);
        Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity);
        Task<ServiceResult<TEntity>> DeleteByIdAsync(int id);
        Task<ServiceResult<TEntity>> GetByIdAsync(params object[] ids);
        Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity);
        Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<ServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
