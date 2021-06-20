using FluentValidation;
using ManaResourceManager;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Query.GetAllAsync
{
    public class GetAllAsyncQueryValidator : AbstractValidator<GetAllAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public GetAllAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Total).NotNull().WithMessage(rms.FetchResource("nototalload").GetMessage());
            RuleFor(c => c.More).NotNull().GreaterThan(0).WithMessage(rms.FetchResource("nomoreload").GetMessage());
        }
    }
}