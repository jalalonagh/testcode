using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public interface IFilter<TEntity, TValid, TSearchEntity>
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearchEntity : BaseSearchEntity, new()
    {
        public Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter);
        public Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, TValid validator);
        public Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search);
    }
}
