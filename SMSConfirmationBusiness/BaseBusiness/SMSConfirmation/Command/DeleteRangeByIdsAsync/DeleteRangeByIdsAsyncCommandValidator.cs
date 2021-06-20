using FluentValidation;
using ManaResourceManager;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandValidator : AbstractValidator<DeleteRangeByIdsAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteRangeByIdsAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.EntityIds).NotNull().WithMessage(rms.FetchResource("idlistempty").GetMessage());
        }
    }
}