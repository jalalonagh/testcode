using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public AddAsyncCommand(PhoneDTO model)
        {
            Model = model;
        }

        public PhoneDTO Model { get; }
    }
}