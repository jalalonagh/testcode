using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services.Models;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public UpdateFieldRangeAsyncCommand(SMSRegexDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public SMSRegexDTO Model { get; }
        public string[] Fields { get; }
    }
}