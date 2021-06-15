using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.SMS.SMS>>
    {
        public UpdateAsyncCommand(SMSDTO model)
        {
            Model = model;
        }

        public SMSDTO Model { get; }
    }
}