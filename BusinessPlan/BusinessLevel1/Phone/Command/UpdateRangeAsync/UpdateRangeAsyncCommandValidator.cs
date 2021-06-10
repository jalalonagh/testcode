using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandValidator : AbstractValidator<UpdateRangeAsyncCommand>
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