using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateAsync
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