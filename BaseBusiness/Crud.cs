using Common;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaViewModel.Common;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public class Crud<TEntity, TSearchEntity, TDTO, TKey> : ICrud<TEntity, TSearchEntity, TDTO, TKey>, IScopedDependency
        where TEntity : BaseEntity, new()
        where TSearchEntity : BaseSearchEntity, new()
        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
        where TKey : struct
    {
        public IBaseService<TEntity, TSearchEntity> service { get; set; }

        public Crud(IBaseService<TEntity, TSearchEntity> _service)
        {
            service = _service;
        }

        public async Task<IServiceResult<TEntity>> AddAsync(TEntity entity)
        {
            return await service.AddAsync(entity);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return await service.AddRangeAsync(entities);
        }
        public async Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity)
        {
            return await service.DeleteAsync(entity);
        }
        public async Task<IServiceResult<TEntity>> DeleteByIdAsync(int id)
        {
            return await service.DeleteByIdAsync(id);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            return await service.DeleteRangeAsync(entities);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            return await service.DeleteRangeByIdsAsync(ids);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            return await service.FilterRangeAsync(filter);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            return await service.GetAllAsync(total, more);
        }
        public async Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            return await service.GetByIdAsync(ids);
        }
        public async Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin)
        {
            return await service.ItemSync(Target, Origin);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            return await service.SearchRangeAsync(search);
        }
        public async Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity)
        {
            return await service.UpdateAsync(entity);
        }
        public async Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
            return await service.UpdateFieldRangeAsync(entity, fields);
        }
        public async Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            return await service.UpdateFieldRangeByIdAsync(Id, fields);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            return await service.UpdateRangeAsync(entities);
        }
    }
}
