﻿using FluentValidation;
using ManaResourceManager;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandValidator : AbstractValidator<DeleteByIdAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteByIdAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.EntityId).NotNull().GreaterThan(0).WithMessage(rms.FetchResource("noid").GetMessage());
        }
    }
}