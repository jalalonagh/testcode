using FluentValidation;

namespace ManaEntitiesValidation.Transaction
{
    internal class TransactionValidator : AbstractValidator<Entities.Transaction.Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.smsId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.transaction).NotNull().WithMessage("");
            RuleFor(x => x.type).NotNull().WithMessage("");
        }
    }
}