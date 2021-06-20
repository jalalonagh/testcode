﻿using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services.Models;
using System.Collections.Generic;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public AddRangeAsyncCommand(IEnumerable<PhoneDTO> model)
        {
            Model = model;
        }

        public IEnumerable<PhoneDTO> Model { get; }
    }
}