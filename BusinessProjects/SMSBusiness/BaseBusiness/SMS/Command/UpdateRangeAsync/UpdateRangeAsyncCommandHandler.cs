using BusinessBaseConfig.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandHandler : ICommandHandler<UpdateRangeAsyncCommand, ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<UpdateRangeAsyncCommandHandler> _logger;

        public UpdateRangeAsyncCommandHandler(ILogger<UpdateRangeAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMS.SMS>>> Handle(UpdateRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}