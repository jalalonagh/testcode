using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteAsync
{
    public class DeleteAsyncCommandValidator : AbstractValidator<DeleteAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}