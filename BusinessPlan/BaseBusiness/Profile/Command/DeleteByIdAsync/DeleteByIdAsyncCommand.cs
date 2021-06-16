using BusinessLayout.Configuration.Commands;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.Profile.Profile>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}