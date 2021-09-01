using FluentValidation;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public interface ICrud<TEntity, TValid, TSearchEntity, TDTO>
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearchEntity : BaseSearchEntity, new()
        where TDTO : BaseDTO<TDTO, TEntity, int>, new()
    {
        public Task<IServiceResult<TEntity>> AddAsync(TEntity entity, TValid validator);
        public Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity, TValid validator);
        public Task<IServiceResult<TEntity>> DeleteByIdAsync(int id);
        public Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids);
        public Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity, TValid validator);
        public Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields);
        public Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
