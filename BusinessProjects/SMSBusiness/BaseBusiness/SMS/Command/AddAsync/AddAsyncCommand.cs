using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services.Models;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.AddAsync
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