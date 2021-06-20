using FluentValidation;
using ManaResourceManager;

namespace UserBusiness.BaseBusinessLevel.User.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryValidator : AbstractValidator<SearchRangeAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public SearchRangeAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("searchmodelempty").GetMessage());
        }
    }
}