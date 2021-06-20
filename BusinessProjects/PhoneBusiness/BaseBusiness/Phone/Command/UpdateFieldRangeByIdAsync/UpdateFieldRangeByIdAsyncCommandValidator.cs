using FluentValidation;
using ManaResourceManager;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandValidator : AbstractValidator<UpdateFieldRangeByIdAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public UpdateFieldRangeByIdAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();
            RuleFor(c => c.EntityId).NotNull().GreaterThan(0).WithMessage(rms.FetchResource("noid").GetMessage());
            RuleFor(c => c.Fields).NotNull().WithMessage(rms.FetchResource("fieldsempty").GetMessage());
        }
    }
}