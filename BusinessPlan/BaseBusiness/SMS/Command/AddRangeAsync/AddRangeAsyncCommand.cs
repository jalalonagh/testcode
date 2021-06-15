using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public AddRangeAsyncCommand(IEnumerable<SMSDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSDTO> Model { get; }
    }
}