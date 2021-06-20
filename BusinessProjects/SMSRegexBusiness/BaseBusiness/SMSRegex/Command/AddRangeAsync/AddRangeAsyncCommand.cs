using BusinessBaseConfig.Configuration.Commands;
using ManaDataTransferObject.SMSRegex;
using Services.Models;
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