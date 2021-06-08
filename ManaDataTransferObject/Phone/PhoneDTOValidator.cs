using FluentValidation;
using ManaDataTransferObject.Common;
using ManaEnums.Entity.Phone;
using ManaResourceManager;

namespace ManaDataTransferObject.Phone
{
    public class PhoneDTOValidator : AbstractValidator<PhoneDTO>
    {
        private ResourceManagerSingleton resource;
        public PhoneDTOValidator()
        {
            resource = ResourceManagerSingleton.Instance;
            RuleFor(x => x.phoneNumber).NotNull().NotEmpty().WithMessage(resource.FetchResource("phoneisrequired").GetMessage());
        }
    }
}
