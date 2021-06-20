using BusinessLayout.Configuration.Commands;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandHandler : ICommandHandler<UpdateFieldRangeAsyncCommand, ServiceResult<Entities.Profile.Profile>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<UpdateFieldRangeAsyncCommandHandler> _logger;

        public UpdateFieldRangeAsyncCommandHandler(ILogger<UpdateFieldRangeAsyncCommandHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Profile.Profile>> Handle(UpdateFieldRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeAsync(request.Model.ToEntity(), request.Fields);
        }
    }
}