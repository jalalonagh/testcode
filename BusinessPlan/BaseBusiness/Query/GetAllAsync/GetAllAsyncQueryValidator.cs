using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.BaseBusiness.Query.GetAllAsync
{
    public class GetAllAsyncQueryValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<GetAllAsyncQuery<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public GetAllAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Total)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("nototalload").GetMessage());

            RuleFor(c => c.More)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("nomoreload").GetMessage());
        }
    }
}