using BusinessBaseConfig.Configuration.Commands;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandHandler : ICommandHandler<DeleteRangeByIdsAsyncCommand, ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<DeleteRangeByIdsAsyncCommandHandler> _logger;

        public DeleteRangeByIdsAsyncCommandHandler(ILogger<DeleteRangeByIdsAsyncCommandHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Phone.Phone>>> Handle(DeleteRangeByIdsAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeByIdsAsync(request.EntityIds);
        }
    }
}