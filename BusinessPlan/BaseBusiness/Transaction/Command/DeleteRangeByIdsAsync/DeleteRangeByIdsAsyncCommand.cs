using BusinessLayout.Configuration.Commands;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        public DeleteRangeByIdsAsyncCommand(IEnumerable<int> ids)
        {
            EntityIds = ids;
        }

        public IEnumerable<int> EntityIds { get; }
    }
}