using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.GetAllAsync
{
    public class GetAllAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<GetAllAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public GetAllAsyncCommandValidator()
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