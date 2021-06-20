using BusinessBaseConfig.Configuration.Commands;
using Services.Models;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}