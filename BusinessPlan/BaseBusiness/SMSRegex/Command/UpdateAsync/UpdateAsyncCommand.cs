using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public UpdateAsyncCommand(SMSRegexDTO model)
        {
            Model = model;
        }

        public SMSRegexDTO Model { get; }
    }
}