using FluentValidation;
using ManaResourceManager;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.DeleteAsync
{
    public class DeleteAsyncCommandValidator : AbstractValidator<DeleteAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}