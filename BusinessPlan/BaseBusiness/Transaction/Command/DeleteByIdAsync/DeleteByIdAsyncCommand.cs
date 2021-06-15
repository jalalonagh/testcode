using BusinessLayout.Configuration.Commands;
using Services;

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