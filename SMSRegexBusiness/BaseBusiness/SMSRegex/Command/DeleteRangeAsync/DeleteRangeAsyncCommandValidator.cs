using FluentValidation;
using ManaResourceManager;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommandValidator : AbstractValidator<DeleteRangeAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modellistempty").GetMessage());
        }
    }
}