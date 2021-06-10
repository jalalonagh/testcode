using FluentValidation;
using ManaDataTransferObject.SMSConfirmation;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.SMSConfirmation
{
    internal class SMSConfirmationDTOValidator : AbstractValidator<SMSConfirmationDTO>
    {
        private ResourceManagerSingleton resource;
        public SMSConfirmationDTOValidator()
        {
            resource = ResourceManagerSingleton.GetInstance();
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("phoneidisrequired").GetMessage());
            RuleFor(x => x.smsId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("smsidisrequired").GetMessage());
            RuleFor(x => x.confirmationText).NotNull().NotEmpty().WithMessage(resource.FetchResource("textisrequired").GetMessage());
        }
    }
}