using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services.Models;
using System.Collections.Generic;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.DeleteRangeAsync
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