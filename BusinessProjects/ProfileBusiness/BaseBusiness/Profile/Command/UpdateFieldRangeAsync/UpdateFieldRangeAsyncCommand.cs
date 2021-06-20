using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand : CommandBase<ServiceResult<Entities.Profile.Profile>>
    {
        public UpdateFieldRangeAsyncCommand(ProfileDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public ProfileDTO Model { get; }
        public string[] Fields { get; }
    }
}