using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services.Models;
using System.Collections.Generic;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        public AddRangeAsyncCommand(IEnumerable<TransactionDTO> model)
        {
            Model = model;
        }

        public IEnumerable<TransactionDTO> Model { get; }
    }
}