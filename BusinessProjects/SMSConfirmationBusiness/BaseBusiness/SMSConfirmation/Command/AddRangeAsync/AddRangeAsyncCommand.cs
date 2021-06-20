using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        public AddRangeAsyncCommand(IEnumerable<SMSConfirmationDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSConfirmationDTO> Model { get; }
    }
}