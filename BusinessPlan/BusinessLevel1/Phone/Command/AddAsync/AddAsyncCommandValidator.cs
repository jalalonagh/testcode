using Entities;
using Entities.Common;
using FluentValidation;
using ManaAutoMapper.Models;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.AddAsync
{
    public class AddAsyncCommandValidator : AbstractValidator<AddAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public AddAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.Model)
                .NotNull()
                .WithMessage(rms.FetchResource("modelempty").GetMessage());
        }
    }
}