using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.AddAsync
{
    public class AddAsyncCommand : CommandBase<ServiceResult<Entities.Profile.Profile>>
    {
        public AddAsyncCommand(ProfileDTO model)
        {
            Model = model;
        }

        public ProfileDTO Model { get; }
    }
}