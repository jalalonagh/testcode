using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<SMSConfirmationDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSConfirmationDTO> Model { get; }
    }
}