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
        public Task<IBusinessResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<IBusinessResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator);
        public Task<IBusinessResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids);
        public Task<IBusinessResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue);
        public Task<IBusinessResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator);
    }
}
