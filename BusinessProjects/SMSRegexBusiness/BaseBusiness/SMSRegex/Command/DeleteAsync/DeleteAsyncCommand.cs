using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services.Models;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteAsync
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