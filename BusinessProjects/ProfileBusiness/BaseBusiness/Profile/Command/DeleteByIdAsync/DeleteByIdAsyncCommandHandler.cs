using BusinessLayout.Configuration.Commands;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandHandler : ICommandHandler<DeleteByIdAsyncCommand, ServiceResult<Entities.Profile.Profile>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<DeleteByIdAsyncCommandHandler> _logger;

        public DeleteByIdAsyncCommandHandler(ILogger<DeleteByIdAsyncCommandHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Profile.Profile>> Handle(DeleteByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteByIdAsync(request.EntityId);
        }
    }
}