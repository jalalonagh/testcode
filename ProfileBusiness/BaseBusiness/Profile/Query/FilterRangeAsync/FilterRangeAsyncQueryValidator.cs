﻿using FluentValidation;
using ManaResourceManager;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryValidator : AbstractValidator<FilterRangeAsyncQuery>
    {
        private ResourceManagerSingleton rms;
        public FilterRangeAsyncQueryValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("filtermodelempty").GetMessage());
        }
    }
}