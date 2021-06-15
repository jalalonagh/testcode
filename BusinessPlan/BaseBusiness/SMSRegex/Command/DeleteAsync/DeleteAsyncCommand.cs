using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public DeleteAsyncCommand(SMSRegexDTO model)
        {
            Model = model;
        }

        public SMSRegexDTO Model { get; }
    }
}