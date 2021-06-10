using FluentValidation;
using ManaDataTransferObject.SMSRegex;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.SMSRegex
{
    internal class SMSRegexDTOValidator : AbstractValidator<SMSRegexDTO>
    {
        private ResourceManagerSingleton resource;
        public SMSRegexDTOValidator()
        {
            resource = ResourceManagerSingleton.GetInstance();
            RuleFor(x => x.regex).NotNull().NotEmpty().WithMessage(resource.FetchResource("regexisrequired").GetMessage());
        }
    }
}