using BusinessBaseConfig.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Command.DeleteAsync
{
    public class DeleteAsyncCommandHandler : ICommandHandler<DeleteAsyncCommand, ServiceResult<Entities.User.User>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<DeleteAsyncCommandHandler> _logger;

        public DeleteAsyncCommandHandler(ILogger<DeleteAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.User.User>> Handle(DeleteAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteAsync(request.Model.ToEntity());
        }
    }
}