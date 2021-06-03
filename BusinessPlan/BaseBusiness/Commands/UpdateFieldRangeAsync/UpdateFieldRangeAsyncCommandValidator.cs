﻿using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.Cart.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandValidator<TEntity, TDTO, TSearch, TKey> : AbstractValidator<UpdateFieldRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>>
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        private ResourceManagerSingleton rms;
        public UpdateFieldRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.Instance;

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modelempty").GetMessage());

            RuleFor(c => c.Fields)
                .NotNull()
                .WithMessage(rms.FetchResource("fieldsempty").GetMessage());
        }
    }
}