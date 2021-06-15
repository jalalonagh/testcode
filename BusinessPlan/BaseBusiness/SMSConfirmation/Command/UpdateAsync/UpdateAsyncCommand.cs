using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services;

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