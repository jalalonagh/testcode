using BusinessBaseConfig.Configuration.Commands;
using Services.Models;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public DeleteByIdAsyncCommand(int id)
        {
            EntityId = id;
        }

        public int EntityId { get; }
    }
}