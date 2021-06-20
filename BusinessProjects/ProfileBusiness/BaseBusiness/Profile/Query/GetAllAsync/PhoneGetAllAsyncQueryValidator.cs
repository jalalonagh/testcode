using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.GetAllAsync
{
    public class ProfileGetAllAsyncQueryValidator : AbstractValidator<ProfileGetAllAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public ProfileGetAllAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Total).NotNull().WithMessage(rms.FetchResource("nototalload").GetMessage());
            RuleFor(c => c.More).NotNull().GreaterThan(0).WithMessage(rms.FetchResource("nomoreload").GetMessage());
        }
    }
}