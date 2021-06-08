using FluentValidation;
using ManaDataTransferObject.Profile.PhoneNumber;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.Profile.PhoneNumber
{
    internal class PhoneNumberDTOValidator : AbstractValidator<PhoneNumberDTO>
    {
        private ResourceManagerSingleton resource;
        public PhoneNumberDTOValidator()
        {
            resource = ResourceManagerSingleton.Instance;
            RuleFor(x => x.Number).NotNull().NotEmpty().WithMessage(resource.FetchResource("phonenumberisrequired").GetMessage());
        }
    }
}