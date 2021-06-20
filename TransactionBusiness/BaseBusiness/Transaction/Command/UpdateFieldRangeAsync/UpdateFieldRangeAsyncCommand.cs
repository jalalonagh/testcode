﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Transaction;
using Services.Models;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.Transaction.Transaction>>
    {
        public UpdateFieldRangeAsyncCommand(TransactionDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public TransactionDTO Model { get; }
        public string[] Fields { get; }
    }
}