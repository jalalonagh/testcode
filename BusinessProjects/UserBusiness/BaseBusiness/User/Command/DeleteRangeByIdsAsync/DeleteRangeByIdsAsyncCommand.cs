using BusinessBaseConfig.Configuration.Commands;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.User.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.User.User>>>
    {
        public DeleteRangeByIdsAsyncCommand(IEnumerable<int> ids)
        {
            EntityIds = ids;
        }

        public IEnumerable<int> EntityIds { get; }
    }
}