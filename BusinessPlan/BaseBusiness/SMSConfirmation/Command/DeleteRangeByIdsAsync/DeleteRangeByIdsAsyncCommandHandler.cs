using BusinessLayout.Configuration.Commands;
using Entities.SMSConfirmation;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandHandler : ICommandHandler<DeleteRangeByIdsAsyncCommand, ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        private readonly IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> _service;
        private readonly ILogger<DeleteRangeByIdsAsyncCommandHandler> _logger;

        public DeleteRangeByIdsAsyncCommandHandler(ILogger<DeleteRangeByIdsAsyncCommandHandler> logger, IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>> Handle(DeleteRangeByIdsAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeByIdsAsync(request.EntityIds);
        }
    }
}