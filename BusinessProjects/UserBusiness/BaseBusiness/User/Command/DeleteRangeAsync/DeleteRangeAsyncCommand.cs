using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.User;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.User.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.User.User>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<UserDTO> model)
        {
            Model = model;
        }

        public IEnumerable<UserDTO> Model { get; }
    }
}