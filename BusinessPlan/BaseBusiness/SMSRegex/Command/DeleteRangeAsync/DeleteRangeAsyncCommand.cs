using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public DeleteRangeAsyncCommand(IEnumerable<SMSRegexDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSRegexDTO> Model { get; }
    }
}