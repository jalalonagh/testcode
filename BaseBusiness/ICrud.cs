using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaViewModel.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public interface ICrud<TEntity, TValid, TSearchEntity, TDTO, TKey>
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearchEntity : BaseSearchEntity, new()
        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
        where TKey : struct
    {
        public Task<IServiceResult<TEntity>> AddAsync(TEntity entity, TValid validator);
        public Task<IServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity, TValid validator);
        public Task<IServiceResult<TEntity>> DeleteByIdAsync(int id);
        public Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        public Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        public Task<IServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        public Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids);
        public Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, TValid validator);
        public Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
        public Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity, TValid validator);
        public Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields);
        public Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
        public Task<IServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator);
    }
}
