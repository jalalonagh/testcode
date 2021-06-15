using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public UpdateRangeAsyncCommand(IEnumerable<SMSRegexDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSRegexDTO> Model { get; }
    }
}