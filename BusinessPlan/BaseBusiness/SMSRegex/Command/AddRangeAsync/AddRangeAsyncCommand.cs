using BusinessLayout.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public AddRangeAsyncCommand(IEnumerable<SMSRegexDTO> model)
        {
            Model = model;
        }

        public IEnumerable<SMSRegexDTO> Model { get; }
    }
}