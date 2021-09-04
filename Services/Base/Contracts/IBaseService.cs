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

        Task<ServiceResult> AddAsync(TEntity entity);
        Task<ServiceResult> DeleteAsync(TEntity entity);
        Task<ServiceResult> DeleteByIdAsync(int id);
        Task<ServiceResult> GetByIdAsync(params object[] ids);
        Task<ServiceResult> UpdateAsync(TEntity entity);
        Task<ServiceResult> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<ServiceResult> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
