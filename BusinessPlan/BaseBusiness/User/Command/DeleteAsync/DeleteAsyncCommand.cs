using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.User;
using Services;

namespace BusinessLayout.BaseBusinessLevel.User.Command.DeleteAsync
{
    public class DeleteAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public DeleteAsyncCommand(UserDTO model)
        {
            Model = model;
        }

        public UserDTO Model { get; }
    }
}