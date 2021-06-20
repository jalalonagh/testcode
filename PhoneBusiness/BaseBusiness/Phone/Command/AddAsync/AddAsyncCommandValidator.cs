using FluentValidation;
using ManaDataTransferObject.Phone;
using ManaResourceManager;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.AddAsync
{
    public class AddAsyncCommandValidator : AbstractValidator<AddAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public AddAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().NotEqual(default(PhoneDTO)).WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}