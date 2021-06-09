using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public AddRangeAsyncCommand(IEnumerable<PhoneDTO> model)
        {
            Model = model;
        }

        public IEnumerable<PhoneDTO> Model { get; }
    }
}