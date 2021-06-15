using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.User;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.User.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.User.User>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<UserDTO> model)
        {
            Model = model;
        }

        public IEnumerable<UserDTO> Model { get; }
    }
}