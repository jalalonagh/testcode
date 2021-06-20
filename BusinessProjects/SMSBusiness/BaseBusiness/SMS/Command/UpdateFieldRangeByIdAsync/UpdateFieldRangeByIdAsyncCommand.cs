using BusinessBaseConfig.Configuration.Commands;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommand : CommandBase<ServiceResult<Entities.SMS.SMS>>
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