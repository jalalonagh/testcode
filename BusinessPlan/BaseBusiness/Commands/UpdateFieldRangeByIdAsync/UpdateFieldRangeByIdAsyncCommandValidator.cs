using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<UpdateFieldRangeByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public UpdateFieldRangeByIdAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.EntityId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("noid").GetMessage());

            RuleFor(c => c.Fields)
                .NotNull()
                .WithMessage(rms.FetchResource("fieldsempty").GetMessage());
        }
    }
}