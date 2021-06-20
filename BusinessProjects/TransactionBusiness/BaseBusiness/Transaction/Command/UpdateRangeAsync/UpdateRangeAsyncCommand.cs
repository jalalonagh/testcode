using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<TransactionDTO> model)
        {
            Model = model;
        }

        public IEnumerable<TransactionDTO> Model { get; }
    }
}