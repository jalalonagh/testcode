using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<PhoneDTO> model)
        {
            Model = model;
        }

        public IEnumerable<PhoneDTO> Model { get; }
    }
}