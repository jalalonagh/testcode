﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.User;
using Services.Models;

namespace UserBusiness.BaseBusinessLevel.User.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public UpdateAsyncCommand(UserDTO model)
        {
            Model = model;
        }

        public UserDTO Model { get; }
    }
}