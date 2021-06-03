using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<DeleteByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public DeleteByIdAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.EntityId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("noid").GetMessage());
        }
    }
}