using BusinessLayout.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteAsync
{
    public class DeleteAsyncCommandHandler : ICommandHandler<DeleteAsyncCommand, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<DeleteAsyncCommandHandler> _logger;

        public DeleteAsyncCommandHandler(ILogger<DeleteAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(DeleteAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteAsync(request.Model.ToEntity());
        }
    }
}