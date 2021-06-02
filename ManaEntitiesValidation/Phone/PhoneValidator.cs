using FluentValidation;

namespace ManaEntitiesValidation.Phone
{
    internal class PhoneValidator : AbstractValidator<Entities.Phone.Phone>
    {
        public PhoneValidator()
        {
            RuleFor(x => x.phoneNumber).NotNull().NotEmpty().WithMessage("شماره موبایل ضروری است");
        }
    }
}