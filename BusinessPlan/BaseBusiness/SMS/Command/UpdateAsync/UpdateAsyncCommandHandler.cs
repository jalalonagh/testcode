using BusinessLayout.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateAsync
{
    public class UpdateAsyncCommandHandler : ICommandHandler<UpdateAsyncCommand, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<UpdateAsyncCommandHandler> _logger;

        public UpdateAsyncCommandHandler(ILogger<UpdateAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(UpdateAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateAsync(request.Model.ToEntity());
        }
    }
}