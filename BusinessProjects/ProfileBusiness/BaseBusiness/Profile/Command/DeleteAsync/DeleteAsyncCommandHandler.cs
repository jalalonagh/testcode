using BusinessBaseConfig.Configuration.Commands;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.DeleteAsync
{
    public class DeleteAsyncCommandHandler : ICommandHandler<DeleteAsyncCommand, ServiceResult<Entities.Profile.Profile>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<DeleteAsyncCommandHandler> _logger;

        public DeleteAsyncCommandHandler(ILogger<DeleteAsyncCommandHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Profile.Profile>> Handle(DeleteAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteAsync(request.Model.ToEntity());
        }
    }
}