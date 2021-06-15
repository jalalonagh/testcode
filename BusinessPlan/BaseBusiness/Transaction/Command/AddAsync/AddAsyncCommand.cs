using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.Transaction.Transaction>>
    {
        public AddAsyncCommand(TransactionDTO model)
        {
            Model = model;
        }

        public TransactionDTO Model { get; }
    }
}