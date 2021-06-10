using FluentValidation;
using ManaDataTransferObject.Transaction;
using ManaResourceManager;

namespace ManaDataTransferObjectValidator.Transaction
{
    internal class TransactionDTOValidator : AbstractValidator<TransactionDTO>
    {
        private ResourceManagerSingleton resource;
        public TransactionDTOValidator()
        {
            resource = ResourceManagerSingleton.GetInstance();
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("phoneidisrequired").GetMessage());
            RuleFor(x => x.smsId).NotNull().GreaterThan(0).WithMessage(resource.FetchResource("smsidisrequired").GetMessage());
            RuleFor(x => x.transaction).NotNull().WithMessage(resource.FetchResource("transactionisrequired").GetMessage());
            RuleFor(x => x.type).NotNull().WithMessage(resource.FetchResource("typeisrequired").GetMessage());
        }
    }
}