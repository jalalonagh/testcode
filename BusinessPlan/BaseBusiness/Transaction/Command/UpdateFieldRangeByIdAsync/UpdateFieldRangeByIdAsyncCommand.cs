using BusinessLayout.Configuration.Commands;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommand : CommandBase<ServiceResult<Entities.Transaction.Transaction>>
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