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

        Task<IServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<IServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<IServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
