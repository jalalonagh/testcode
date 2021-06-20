using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.SMS.SMS>>
    {
        public DeleteAsyncCommand(SMSDTO model)
        {
            Model = model;
        }

        public SMSDTO Model { get; }
    }
}