using FluentValidation;
using ManaResourceManager;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandValidator : AbstractValidator<DeleteRangeByIdsAsyncCommand>
    {
        private ResourceManagerSingleton rms;
        public DeleteRangeByIdsAsyncCommandValidator()
        {
            rms = ResourceManagerSingleton.GetInstance();

            RuleFor(c => c.EntityIds)
                .NotNull()
                .WithMessage(rms.FetchResource("idlistempty").GetMessage());
        }
    }
}