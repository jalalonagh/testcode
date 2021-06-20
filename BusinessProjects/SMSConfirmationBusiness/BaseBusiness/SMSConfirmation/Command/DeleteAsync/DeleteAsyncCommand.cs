using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services.Models;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public DeleteAsyncCommand(SMSConfirmationDTO model)
        {
            Model = model;
        }

        public SMSConfirmationDTO Model { get; }
    }
}