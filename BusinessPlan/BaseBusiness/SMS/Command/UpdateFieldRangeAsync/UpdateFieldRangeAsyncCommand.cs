using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateFieldRangeAsync
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