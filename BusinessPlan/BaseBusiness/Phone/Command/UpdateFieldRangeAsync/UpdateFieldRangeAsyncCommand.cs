﻿using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public UpdateFieldRangeAsyncCommand(PhoneDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public PhoneDTO Model { get; }
        public string[] Fields { get; }
    }
}