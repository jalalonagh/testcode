using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public DeleteAsyncCommand(PhoneDTO model)
        {
            Model = model;
        }

        public PhoneDTO Model { get; }
    }
}