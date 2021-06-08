using FluentValidation;
using ManaDataTransferObject.Phone;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.Phone
{
    internal class PhoneDTOValidator : AbstractValidator<PhoneDTO>
    {
        private ResourceManagerSingleton resource;
        public PhoneDTOValidator()
        {
            resource = ResourceManagerSingleton.Instance;
            RuleFor(x => x.phoneNumber).NotNull().NotEmpty().WithMessage(resource.FetchResource("phoneisrequired").GetMessage());
        }
    }
}