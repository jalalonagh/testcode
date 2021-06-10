using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryValidator : AbstractValidator<GetByIdAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public GetByIdAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.EntityIds)
                .NotNull()
                .NotEmpty()
                .WithMessage(rms.FetchResource("noids").GetMessage());
        }
    }
}