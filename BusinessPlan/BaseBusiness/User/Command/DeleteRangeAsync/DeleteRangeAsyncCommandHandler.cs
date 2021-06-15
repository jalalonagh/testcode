using BusinessLayout.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommandHandler : ICommandHandler<DeleteRangeAsyncCommand, ServiceResult<IEnumerable<Entities.User.User>>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<DeleteRangeAsyncCommandHandler> _logger;

        public DeleteRangeAsyncCommandHandler(ILogger<DeleteRangeAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.User.User>>> Handle(DeleteRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}