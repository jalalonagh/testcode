using ManaBaseData.Repositories;
using ManaBaseEntity.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IBaseRangeService<TEntity>
        where TEntity : class, IEntity
    {
        IRangeRepository<TEntity> repository { get; }

        Task<ServiceResult> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<ServiceResult> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<ServiceResult> UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
