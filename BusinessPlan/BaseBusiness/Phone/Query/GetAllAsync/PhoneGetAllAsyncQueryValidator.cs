using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel.Phone.Query.GetAllAsync
{
    public class PhoneGetAllAsyncQueryValidator : AbstractValidator<PhoneGetAllAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public PhoneGetAllAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.Total)
                .NotNull()
                .WithMessage(rms.FetchResource("nototalload").GetMessage());

            RuleFor(c => c.More)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(rms.FetchResource("nomoreload").GetMessage());
        }
    }
}