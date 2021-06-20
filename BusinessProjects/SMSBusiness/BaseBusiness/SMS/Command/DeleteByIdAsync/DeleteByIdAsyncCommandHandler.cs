using BusinessBaseConfig.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandHandler : ICommandHandler<DeleteByIdAsyncCommand, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<DeleteByIdAsyncCommandHandler> _logger;

        public DeleteByIdAsyncCommandHandler(ILogger<DeleteByIdAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(DeleteByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteByIdAsync(request.EntityId);
        }
    }
}