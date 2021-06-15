using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSConfirmation;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public UpdateFieldRangeAsyncCommand(SMSConfirmationDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public SMSConfirmationDTO Model { get; }
        public string[] Fields { get; }
    }
}