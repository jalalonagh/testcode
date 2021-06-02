using FluentValidation;

namespace ManaEntitiesValidation.Profile
{
    internal class ProfileValidator : AbstractValidator<Entities.Profile.Profile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.PhoneNumberId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.Points).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.ProfileTypeId).NotNull().GreaterThan(0).WithMessage("");
        }
    }
}