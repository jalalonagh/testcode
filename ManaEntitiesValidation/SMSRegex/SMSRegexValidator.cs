using FluentValidation;

namespace ManaEntitiesValidation.SMSRegex
{
    internal class SMSRegexValidator : AbstractValidator<Entities.SMSRegex.SMSRegex>
    {
        public SMSRegexValidator()
        {
            RuleFor(x => x.regex).NotNull().NotEmpty().WithMessage("");
        }
    }
}