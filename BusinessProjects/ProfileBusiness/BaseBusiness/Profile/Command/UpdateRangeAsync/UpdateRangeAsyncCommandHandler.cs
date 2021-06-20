using BusinessLayout.Configuration.Commands;
using Entities.Profile;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandHandler : ICommandHandler<UpdateRangeAsyncCommand, ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        private readonly IBaseService<Entities.Profile.Profile, ProfileSearch> _service;
        private readonly ILogger<UpdateRangeAsyncCommandHandler> _logger;

        public UpdateRangeAsyncCommandHandler(ILogger<UpdateRangeAsyncCommandHandler> logger, IBaseService<Entities.Profile.Profile, ProfileSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Profile.Profile>>> Handle(UpdateRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}