using BusinessBaseConfig.Configuration.Commands;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.SMS.SMS>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}