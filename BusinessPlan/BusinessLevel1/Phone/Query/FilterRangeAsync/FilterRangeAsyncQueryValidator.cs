using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryValidator : AbstractValidator<FilterRangeAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public FilterRangeAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("filtermodelempty").GetMessage());
        }
    }
}