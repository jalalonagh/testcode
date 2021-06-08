using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.GetByIdAsync
{
    public class GetByIdAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<GetByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public GetByIdAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.EntityIds)
                .NotNull()
                .NotEmpty()
                .WithMessage(rms.FetchResource("noids").GetMessage());
        }
    }
}