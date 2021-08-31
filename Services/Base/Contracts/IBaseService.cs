using ManaBaseData.Repositories;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IBaseService<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        IRepository<TEntity, TSearchEntity> repository { get; }

        Task<IServiceResult<TEntity>> AddAsync(TEntity entity);
        Task<IServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity);
        Task<IServiceResult<TEntity>> DeleteByIdAsync(int id);
        Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids);
        Task<IServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity);
        Task<IServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
        Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
        Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin);
    }
}
