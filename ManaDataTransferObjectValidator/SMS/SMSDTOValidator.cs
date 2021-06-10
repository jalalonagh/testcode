using FluentValidation;
using ManaDataTransferObject.SMS;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.SMS
{
    internal class SMSDTOValidator : AbstractValidator<SMSDTO>
    {
        private ResourceManagerSingleton resource;
        public SMSDTOValidator()
        {
            resource = ResourceManagerSingleton.GetInstance();
            RuleFor(x => x.phone).NotNull().NotEmpty().WithMessage(resource.FetchResource("phoneisrequired").GetMessage());
            RuleFor(x => x.smsText).NotNull().NotEmpty().WithMessage(resource.FetchResource("textisrequired").GetMessage());
        }
    }
}