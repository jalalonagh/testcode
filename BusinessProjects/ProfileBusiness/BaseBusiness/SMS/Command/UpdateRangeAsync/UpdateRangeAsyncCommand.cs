using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<SMSDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSDTO> Model { get; }
    }
}