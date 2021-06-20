﻿using BusinessBaseConfig.Configuration.Commands;
using Services.Models;

namespace UserBusiness.BaseBusinessLevel.User.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}