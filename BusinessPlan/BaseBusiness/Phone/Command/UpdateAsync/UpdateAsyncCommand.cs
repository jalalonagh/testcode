using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public UpdateAsyncCommand(PhoneDTO model)
        {
            Model = model;
        }

        public PhoneDTO Model { get; }
    }
}