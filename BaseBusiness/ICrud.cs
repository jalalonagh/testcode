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
        public Task<BusinessResult<TEntity>> AddAsync(TEntity entity, TValid validator);
        public Task<BusinessResult<TEntity>> DeleteAsync(TEntity entity, TValid validator);
        public Task<BusinessResult<TEntity>> DeleteByIdAsync(int id);
        public Task<BusinessResult<TEntity>> GetByIdAsync(params object[] ids);
        public Task<BusinessResult<TEntity>> UpdateAsync(TEntity entity, TValid validator);
        public Task<BusinessResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields);
        public Task<BusinessResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
