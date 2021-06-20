using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<SMSConfirmationDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSConfirmationDTO> Model { get; }
    }
}