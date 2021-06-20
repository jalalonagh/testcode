using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeAsync
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