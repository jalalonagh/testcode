using FluentValidation;
using ManaResourceManager;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.AddAsync
{
    public class AddAsyncCommandValidator : AbstractValidator<AddAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public AddAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}