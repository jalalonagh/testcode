using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.User;
using Services.Models;

namespace UserBusiness.BaseBusinessLevel.User.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public AddAsyncCommand(UserDTO model)
        {
            Model = model;
        }

        public UserDTO Model { get; }
    }
}