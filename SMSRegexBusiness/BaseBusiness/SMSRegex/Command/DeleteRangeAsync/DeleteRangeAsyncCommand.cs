﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services.Models;
using System.Collections.Generic;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<SMSRegexDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSRegexDTO> Model { get; }
    }
}