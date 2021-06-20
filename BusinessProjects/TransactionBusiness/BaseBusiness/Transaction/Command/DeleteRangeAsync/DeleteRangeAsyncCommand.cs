using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services.Models;
using System.Collections.Generic;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<TransactionDTO> model)
        {
            Model = model;
        }

        public IEnumerable<TransactionDTO> Model { get; }
    }
}