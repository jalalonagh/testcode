using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.BaseBusiness.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<GetByIdAsyncQuery<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public GetByIdAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.EntityIds)
                .NotNull()
                .NotEmpty()
                .WithMessage(rms.FetchResource("noids").GetMessage());
        }
    }
}