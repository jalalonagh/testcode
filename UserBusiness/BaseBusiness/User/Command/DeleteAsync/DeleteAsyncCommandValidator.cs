﻿using FluentValidation;
using ManaResourceManager;

namespace UserBusiness.BaseBusinessLevel.User.Command.DeleteAsync
{
    public class DeleteAsyncCommandValidator : AbstractValidator<DeleteAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}