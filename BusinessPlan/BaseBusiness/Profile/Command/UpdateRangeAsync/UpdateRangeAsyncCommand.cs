using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<ProfileDTO> model)
        {
            Model = model;
        }

        public IEnumerable<ProfileDTO> Model { get; }
    }
}