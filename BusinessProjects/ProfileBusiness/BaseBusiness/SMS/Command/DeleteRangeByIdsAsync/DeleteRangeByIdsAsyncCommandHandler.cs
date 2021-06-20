using BusinessLayout.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMS.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandHandler : ICommandHandler<DeleteRangeByIdsAsyncCommand, ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<DeleteRangeByIdsAsyncCommandHandler> _logger;

        public DeleteRangeByIdsAsyncCommandHandler(ILogger<DeleteRangeByIdsAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMS.SMS>>> Handle(DeleteRangeByIdsAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeByIdsAsync(request.EntityIds);
        }
    }
}