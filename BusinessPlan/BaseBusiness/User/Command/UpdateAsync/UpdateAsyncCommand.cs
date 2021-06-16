using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.User;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.User.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public UpdateAsyncCommand(UserDTO model)
        {
            Model = model;
        }

        public UserDTO Model { get; }
    }
}