using BusinessLayout.Configuration.Commands;
using Entities.User;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.User.Command.AddAsync
{
    public class AddAsyncCommandHandler : ICommandHandler<AddAsyncCommand, ServiceResult<Entities.User.User>>
    {
        private readonly IBaseService<Entities.User.User, UserSearch> _service;
        private readonly ILogger<AddAsyncCommandHandler> _logger;

        public AddAsyncCommandHandler(ILogger<AddAsyncCommandHandler> logger, IBaseService<Entities.User.User, UserSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.User.User>> Handle(AddAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddAsync(request.Model.ToEntity());
        }
    }
}