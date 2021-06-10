﻿using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandValidator : AbstractValidator<AddRangeAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public AddRangeAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modellistempty").GetMessage());
        }
    }
}