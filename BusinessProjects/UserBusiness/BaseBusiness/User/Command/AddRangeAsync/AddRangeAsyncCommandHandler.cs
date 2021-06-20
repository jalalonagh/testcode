using BusinessBaseConfig.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UserBusiness.BaseBusinessLevel.User.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandHandler : ICommandHandler<AddRangeAsyncCommand, ServiceResult<IEnumerable<Entities.User.User>>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<AddRangeAsyncCommandHandler> _logger;

        public AddRangeAsyncCommandHandler(ILogger<AddRangeAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.User.User>>> Handle(AddRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}