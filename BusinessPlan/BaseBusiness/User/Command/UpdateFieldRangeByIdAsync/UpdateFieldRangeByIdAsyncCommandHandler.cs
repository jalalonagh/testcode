using BusinessLayout.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandHandler : ICommandHandler<UpdateFieldRangeByIdAsyncCommand, ServiceResult<Entities.User.User>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<UpdateFieldRangeByIdAsyncCommandHandler> _logger;

        public UpdateFieldRangeByIdAsyncCommandHandler(ILogger<UpdateFieldRangeByIdAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.User.User>> Handle(UpdateFieldRangeByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeByIdAsync(request.EntityId, request.Fields);
        }
    }
}