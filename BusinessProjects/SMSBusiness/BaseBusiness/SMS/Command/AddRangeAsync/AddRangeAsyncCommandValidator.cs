using FluentValidation;
using ManaResourceManager;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandValidator : AbstractValidator<AddRangeAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public AddRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modellistempty").GetMessage());
        }
    }
}