using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using ManaDataTransferObject.Phone;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public DeleteAsyncCommand(PhoneDTO model)
        {
            Model = model;
        }

        public PhoneDTO Model { get; }
    }
}