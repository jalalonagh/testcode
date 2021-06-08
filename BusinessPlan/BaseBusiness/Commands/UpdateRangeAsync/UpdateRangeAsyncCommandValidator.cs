using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<UpdateRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public UpdateRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modellistempty").GetMessage());
        }
    }
}