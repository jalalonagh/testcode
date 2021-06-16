using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<ProfileDTO> model)
        {
            Model = model;
        }

        public IEnumerable<ProfileDTO> Model { get; }
    }
}