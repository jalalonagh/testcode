﻿using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.Profile.Profile>>
    {
        public DeleteAsyncCommand(ProfileDTO model)
        {
            Model = model;
        }

        public ProfileDTO Model { get; }
    }
}