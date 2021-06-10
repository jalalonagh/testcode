using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteByIdAsync
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