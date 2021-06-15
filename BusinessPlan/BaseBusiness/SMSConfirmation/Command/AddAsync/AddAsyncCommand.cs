using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public AddAsyncCommand(SMSConfirmationDTO model)
        {
            Model = model;
        }

        public SMSConfirmationDTO Model { get; }
    }
}