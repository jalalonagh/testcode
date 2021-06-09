﻿using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.BaseBusiness.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<FilterRangeAsyncQuery<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
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