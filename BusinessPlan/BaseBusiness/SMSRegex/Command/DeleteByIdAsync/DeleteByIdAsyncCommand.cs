using BusinessLayout.Configuration.Commands;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}