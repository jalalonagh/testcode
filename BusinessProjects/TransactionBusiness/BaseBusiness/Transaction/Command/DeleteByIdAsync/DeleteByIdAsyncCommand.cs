using BusinessBaseConfig.Configuration.Commands;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.Transaction.Transaction>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}