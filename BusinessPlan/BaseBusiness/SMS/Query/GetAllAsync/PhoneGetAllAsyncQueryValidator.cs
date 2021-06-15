using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel.SMS.Query.GetAllAsync
{
    public class SMSGetAllAsyncQueryValidator : AbstractValidator<SMSGetAllAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public SMSGetAllAsyncQueryValidator()
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