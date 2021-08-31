using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.Profile;
using Services.Models;
using System.Collections.Generic;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        public AddRangeAsyncCommand(IEnumerable<ProfileDTO> model)
        {
            Model = model;
        }

        public IEnumerable<ProfileDTO> Model { get; }
    }
}