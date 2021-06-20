using BusinessBaseConfig.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommandHandler : ICommandHandler<DeleteRangeAsyncCommand, ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<DeleteRangeAsyncCommandHandler> _logger;

        public DeleteRangeAsyncCommandHandler(ILogger<DeleteRangeAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMS.SMS>>> Handle(DeleteRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}