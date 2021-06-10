using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandValidator : AbstractValidator<DeleteByIdAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteByIdAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.EntityId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("noid").GetMessage());
        }
    }
}