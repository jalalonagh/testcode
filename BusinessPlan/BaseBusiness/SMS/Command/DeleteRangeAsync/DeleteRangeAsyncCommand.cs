using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMS;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<SMSDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSDTO> Model { get; }
    }
}