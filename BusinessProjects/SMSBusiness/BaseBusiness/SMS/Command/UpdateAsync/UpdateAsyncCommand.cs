using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services.Models;

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