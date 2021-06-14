using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.UpdateAsync
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