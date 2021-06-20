using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.User;
using Services.Models;

namespace UserBusiness.BaseBusinessLevel.User.Command.DeleteAsync
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