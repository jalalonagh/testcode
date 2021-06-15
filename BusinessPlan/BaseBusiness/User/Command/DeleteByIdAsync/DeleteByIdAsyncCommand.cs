using BusinessLayout.Configuration.Commands;
using Services;

namespace BusinessLayout.BaseBusinessLevel.User.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.User.User>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}