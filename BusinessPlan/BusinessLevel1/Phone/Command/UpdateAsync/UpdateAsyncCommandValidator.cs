using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateAsync
{
    public class UpdateAsyncCommandValidator : AbstractValidator<UpdateAsyncCommand>
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