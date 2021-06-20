﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services.Models;
using System.Collections.Generic;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<SMSDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSDTO> Model { get; }
    }
}