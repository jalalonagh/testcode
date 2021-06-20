using BusinessLayout.Configuration.Commands;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommand : CommandBase<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public UpdateFieldRangeByIdAsyncCommand(int id, params KeyValuePair<string, dynamic>[] fields)
        {
            EntityId = id;
            Fields = fields;
        }

        public int EntityId { get; }
        public KeyValuePair<string, dynamic>[] Fields { get; }
    }
}