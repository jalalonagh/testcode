using BusinessLayout.Configuration.Commands;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public DeleteRangeByIdsAsyncCommand(IEnumerable<int> ids)
        {
            EntityIds = ids;
        }

        public IEnumerable<int> EntityIds { get; }
    }
}