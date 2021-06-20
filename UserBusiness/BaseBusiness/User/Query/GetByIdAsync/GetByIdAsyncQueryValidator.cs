using FluentValidation;
using ManaResourceManager;

namespace UserBusiness.BaseBusinessLevel.User.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryValidator : AbstractValidator<GetByIdAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public GetByIdAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.EntityIds)
                .NotNull()
                .NotEmpty()
                .WithMessage(rms.FetchResource("noids").GetMessage());
        }
    }
}