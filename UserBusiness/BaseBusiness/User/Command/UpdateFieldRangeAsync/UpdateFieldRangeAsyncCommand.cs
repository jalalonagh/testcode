﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.User;
using Services.Models;

namespace UserBusiness.BaseBusinessLevel.User.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public UpdateFieldRangeAsyncCommand(UserDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public UserDTO Model { get; }
        public string[] Fields { get; }
    }
}