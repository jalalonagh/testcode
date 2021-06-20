using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services.Models;

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