using BusinessBaseConfig.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandHandler : ICommandHandler<UpdateFieldRangeAsyncCommand, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<UpdateFieldRangeAsyncCommandHandler> _logger;

        public UpdateFieldRangeAsyncCommandHandler(ILogger<UpdateFieldRangeAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(UpdateFieldRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeAsync(request.Model.ToEntity(), request.Fields);
        }
    }
}