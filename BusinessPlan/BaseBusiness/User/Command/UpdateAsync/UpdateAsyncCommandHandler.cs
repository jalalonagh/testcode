using BusinessLayout.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Command.UpdateAsync
{
    public class UpdateAsyncCommandHandler : ICommandHandler<UpdateAsyncCommand, ServiceResult<Entities.User.User>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<UpdateAsyncCommandHandler> _logger;

        public UpdateAsyncCommandHandler(ILogger<UpdateAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.User.User>> Handle(UpdateAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateAsync(request.Model.ToEntity());
        }
    }
}