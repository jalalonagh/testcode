using FluentValidation;

namespace ManaEntitiesValidation.SMSConfirmation
{
    internal class SMSConfirmationValidator : AbstractValidator<Entities.SMSConfirmation.SMSConfirmation>
    {
        public SMSConfirmationValidator()
        {
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.smsId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.confirmationText).NotNull().NotEmpty().WithMessage("");
        }
    }
}