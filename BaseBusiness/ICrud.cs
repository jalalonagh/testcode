using BaseBusiness.Models;
using FluentValidation;
using ManaBaseEntity.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public interface ICrud<TEntity, TValid>
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
    {
        public Task<IBusinessResult<TEntity>> AddAsync(TEntity entity, TValid validator);
        public Task<IBusinessResult<TEntity>> DeleteAsync(TEntity entity, TValid validator);
        public Task<IBusinessResult<TEntity>> DeleteByIdAsync(int id);
        public Task<IBusinessResult<TEntity>> GetByIdAsync(params object[] ids);
        public Task<IBusinessResult<TEntity>> UpdateAsync(TEntity entity, TValid validator);
        public Task<IBusinessResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields);
        public Task<IBusinessResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
