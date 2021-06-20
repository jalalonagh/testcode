﻿using FluentValidation;
using ManaResourceManager;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandValidator : AbstractValidator<AddRangeAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public AddRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.Model).NotNull().WithMessage(rms.FetchResource("modellistempty").GetMessage());
        }
    }
}