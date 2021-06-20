﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.Transaction.Transaction>>
    {
        public DeleteAsyncCommand(TransactionDTO model)
        {
            Model = model;
        }

        public TransactionDTO Model { get; }
    }
}