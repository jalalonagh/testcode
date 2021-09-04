using BaseBusiness.Models;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public interface IFilter<TEntity, TValid, TSearchEntity>
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearchEntity : BaseSearchEntity, new()
    {
        public Task<IBusinessResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        public Task<IBusinessResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, TValid validator);
        public Task<IBusinessResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
    }
}
