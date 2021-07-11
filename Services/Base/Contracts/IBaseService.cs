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

        Task<ServiceResult<TEntity>> AddAsync(TEntity entity);
        Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity);
        Task<ServiceResult<TEntity>> DeleteByIdAsync(int id);
        Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        Task<ServiceResult<TEntity>> GetByIdAsync(params object[] ids);
        Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity);
        Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task<ServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        Task<ServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
        Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields);
        Task<ServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
        Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin);
    }
}
