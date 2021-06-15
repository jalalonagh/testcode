using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.SMS.SMS>>
    {
        public AddAsyncCommand(SMSDTO model)
        {
            Model = model;
        }

        public SMSDTO Model { get; }
    }
}