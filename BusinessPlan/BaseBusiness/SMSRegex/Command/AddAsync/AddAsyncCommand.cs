using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public AddAsyncCommand(SMSRegexDTO model)
        {
            Model = model;
        }

        public SMSRegexDTO Model { get; }
    }
}