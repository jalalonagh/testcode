using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;
using Services.Models;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Command.UpdateAsync
{
    public class UpdateAsyncCommand : CommandBase<ServiceResult<Entities.Profile.Profile>>
    {
        public UpdateAsyncCommand(ProfileDTO model)
        {
            Model = model;
        }

        public ProfileDTO Model { get; }
    }
}