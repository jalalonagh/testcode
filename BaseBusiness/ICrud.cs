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
        public Task<BusinessResult> AddAsync(TEntity entity, TValid validator);
        public Task<BusinessResult> DeleteAsync(TEntity entity, TValid validator);
        public Task<BusinessResult> DeleteByIdAsync(int id);
        public Task<BusinessResult> GetByIdAsync(params object[] ids);
        public Task<BusinessResult> UpdateAsync(TEntity entity, TValid validator);
        public Task<BusinessResult> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields);
        public Task<BusinessResult> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields);
    }
}
