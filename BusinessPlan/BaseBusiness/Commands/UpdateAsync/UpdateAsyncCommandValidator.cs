using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.UpdateAsync
{
    public class UpdateAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<UpdateAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public UpdateAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}