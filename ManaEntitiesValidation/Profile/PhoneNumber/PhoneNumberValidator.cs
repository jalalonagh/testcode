using FluentValidation;

namespace ManaEntitiesValidation.Profile.PhoneNumber
{
    internal class PhoneNumberValidator : AbstractValidator<Entities.Profile.PhoneNumber.PhoneNumber>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty().WithMessage("شناسه محصول ضروری است");
        }
    }
}