using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryValidator : AbstractValidator<SearchRangeAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public SearchRangeAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("searchmodelempty").GetMessage());
        }
    }
}