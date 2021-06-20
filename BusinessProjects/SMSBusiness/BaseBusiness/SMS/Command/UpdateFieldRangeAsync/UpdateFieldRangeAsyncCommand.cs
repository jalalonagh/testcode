using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services.Models;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.SMS.SMS>>
    {
        public UpdateFieldRangeAsyncCommand(SMSDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public SMSDTO Model { get; }
        public string[] Fields { get; }
    }
}