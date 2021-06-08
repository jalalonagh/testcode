using FluentValidation;
using ManaResourceManager;

namespace ManaEntitiesValidation.Profile
{
    internal class ProfileValidator : AbstractValidator<Entities.Profile.Profile>
    {
        private ResourceManagerSingleton resource;
        public ProfileValidator()
        {
            resource = ResourceManagerSingleton.Instance;
            RuleFor(x => x.UserId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("useridisrequired").GetMessage());
            RuleFor(x => x.PhoneNumberId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("phonenumberidisrequired").GetMessage());
            RuleFor(x => x.Points).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("pointsisrequired").GetMessage());
            RuleFor(x => x.ProfileTypeId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("profiletypeisrequired").GetMessage());
        }
    }
}