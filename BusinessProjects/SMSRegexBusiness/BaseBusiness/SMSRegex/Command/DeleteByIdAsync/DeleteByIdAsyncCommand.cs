using BusinessBaseConfig.Configuration.Commands;
using Services.Models;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteByIdAsync
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