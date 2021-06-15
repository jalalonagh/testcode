﻿using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandValidator : AbstractValidator<UpdateFieldRangeAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public UpdateFieldRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modelempty").GetMessage());

            RuleFor(c => c.Fields)
                .NotNull()
                .WithMessage(rms.FetchResource("fieldsempty").GetMessage());
        }
    }
}