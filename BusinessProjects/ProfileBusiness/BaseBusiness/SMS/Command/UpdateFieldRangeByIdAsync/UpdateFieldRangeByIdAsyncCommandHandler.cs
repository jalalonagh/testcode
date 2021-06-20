using BusinessLayout.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandHandler : ICommandHandler<UpdateFieldRangeByIdAsyncCommand, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<UpdateFieldRangeByIdAsyncCommandHandler> _logger;

        public UpdateFieldRangeByIdAsyncCommandHandler(ILogger<UpdateFieldRangeByIdAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(UpdateFieldRangeByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeByIdAsync(request.EntityId, request.Fields);
        }
    }
}