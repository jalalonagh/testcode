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

        Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
