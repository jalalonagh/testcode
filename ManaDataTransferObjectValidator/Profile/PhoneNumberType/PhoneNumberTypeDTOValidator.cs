using FluentValidation;
using ManaDataTransferObject.Profile.PhoneNumberType;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.Profile.PhoneNumberType
{
    internal class PhoneNumberTypeDTOValidator : AbstractValidator<PhoneNumberTypeDTO>
    {
        private ResourceManagerSingleton resource;
        public PhoneNumberTypeDTOValidator()
        {
            resource = ResourceManagerSingleton.GetInstance();
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(resource.FetchResource("descriptionisrequired").GetMessage());
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("idisrequired").GetMessage());
        }
    }
}