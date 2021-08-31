using FluentValidation;

namespace ManaEntitiesValidation.SMS
{
    internal class SMSValidator : AbstractValidator<Entities.SMS.SMS>
    {
        public SMSValidator()
        {
            RuleFor(x => x.phone).NotNull().NotEmpty().WithMessage("");
            RuleFor(x => x.smsText).NotNull().NotEmpty().WithMessage("");
        }
    }
}