using FluentValidation;
using ManaResourceManager;

namespace ManaEntitiesValidation.Phone
{
    internal class PhoneValidator : AbstractValidator<Entities.Phone.Phone>
    {
        private ResourceManagerSingleton resource;
        public PhoneValidator()
        {
            resource = ResourceManagerSingleton.GetInstance();
            RuleFor(x => x.phoneNumber).NotNull().NotEmpty().WithMessage(resource.FetchResource("phoneisrequired").GetMessage());
        }
    }
}