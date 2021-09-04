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
        public Task<BusinessResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<BusinessResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<BusinessResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        public Task<BusinessResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        public Task<BusinessResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator);
    }
}
