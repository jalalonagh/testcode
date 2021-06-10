using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.GetAllAsync
{
    public class GetAllAsyncQueryValidator : AbstractValidator<GetAllAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public GetAllAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Total)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("nototalload").GetMessage());

            RuleFor(c => c.More)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("nomoreload").GetMessage());
        }
    }
}