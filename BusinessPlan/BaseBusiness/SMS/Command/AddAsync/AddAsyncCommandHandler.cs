using BusinessLayout.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.AddAsync
{
    public class AddAsyncCommandHandler : ICommandHandler<AddAsyncCommand, ServiceResult<Entities.SMS.SMS>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<AddAsyncCommandHandler> _logger;

        public AddAsyncCommandHandler(ILogger<AddAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMS.SMS>> Handle(AddAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddAsync(request.Model.ToEntity());
        }
    }
}