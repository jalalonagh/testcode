using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.Transaction.Transaction>>
    {
        public UpdateAsyncCommand(TransactionDTO model)
        {
            Model = model;
        }

        public TransactionDTO Model { get; }
    }
}