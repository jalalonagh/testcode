using BusinessLayout.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandHandler : ICommandHandler<UpdateFieldRangeAsyncCommand, ServiceResult<Entities.User.User>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<UpdateFieldRangeAsyncCommandHandler> _logger;

        public UpdateFieldRangeAsyncCommandHandler(ILogger<UpdateFieldRangeAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.User.User>> Handle(UpdateFieldRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeAsync(request.Model.ToEntity(), request.Fields);
        }
    }
}