using FluentValidation;
using ManaDataTransferObject.ConfirmedTransaction;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.ConfirmedTransaction
{
    internal class ConfirmedTransactionDTOValidator : AbstractValidator<ConfirmedTransactionDTO>
    {
        private ResourceManagerSingleton resource;
        public ConfirmedTransactionDTOValidator()
        {
            resource = ResourceManagerSingleton.Instance;
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("phoneidisrequired").GetMessage());
            RuleFor(x => x.transactionId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("transactionidisrequired").GetMessage());
        }
    }
}