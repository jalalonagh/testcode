using BaseBusiness.Models;
using FluentValidation;
using ManaBaseEntity.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public interface ICrudRange<TEntity, TValid>
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
    {
        public Task<BusinessResult> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<BusinessResult> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<BusinessResult> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        public Task<BusinessResult> GetAllAsync(int total = 0, int more = int.MaxValue);
        public Task<BusinessResult> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator);
    }
}
