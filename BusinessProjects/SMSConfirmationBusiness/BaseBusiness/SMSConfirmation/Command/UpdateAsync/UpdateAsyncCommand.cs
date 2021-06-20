using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public UpdateAsyncCommand(SMSConfirmationDTO model)
        {
            Model = model;
        }

        public SMSConfirmationDTO Model { get; }
    }
}