using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandValidator : AbstractValidator<UpdateRangeAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public UpdateRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modellistempty").GetMessage());
        }
    }
}