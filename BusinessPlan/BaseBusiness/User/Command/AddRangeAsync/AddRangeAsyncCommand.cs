using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.User;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.User.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.User.User>>>
    {
        public AddRangeAsyncCommand(IEnumerable<UserDTO> model)
        {
            Model = model;
        }

        public IEnumerable<UserDTO> Model { get; }
    }
}