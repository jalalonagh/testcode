using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Phone;
using Services.Models;
using System.Collections.Generic;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<PhoneDTO> model)
        {
            Model = model;
        }

        public IEnumerable<PhoneDTO> Model { get; }
    }
}