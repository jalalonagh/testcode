using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<DeleteRangeByIdsAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public DeleteRangeByIdsAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.EntityIds)
                .NotNull()
                .WithMessage(rms.FetchResource("idlistempty").GetMessage());
        }
    }
}