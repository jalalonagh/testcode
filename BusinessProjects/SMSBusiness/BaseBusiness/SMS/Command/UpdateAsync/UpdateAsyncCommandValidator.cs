using FluentValidation;
using ManaResourceManager;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateAsync
{
    public class UpdateAsyncCommandValidator : AbstractValidator<UpdateAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public UpdateAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}