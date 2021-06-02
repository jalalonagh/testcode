using FluentValidation;

namespace ManaEntitiesValidation.ConfirmedTransaction
{
    internal class ConfirmedTransactionValidator : AbstractValidator<Entities.ConfirmedTransaction.ConfirmedTransaction>
    {
        public ConfirmedTransactionValidator()
        {
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage("شناسه شماره موبایل ضروری است");
            RuleFor(x => x.transactionId).NotNull().GreaterThan(0).WithMessage("شناسه تراکنش ضروری است");
        }
    }
}