using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services.Models;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Command.AddAsync
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