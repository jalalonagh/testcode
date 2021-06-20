using BusinessBaseConfig.Configuration.Commands;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommandHandler : ICommandHandler<DeleteRangeAsyncCommand, ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<DeleteRangeAsyncCommandHandler> _logger;

        public DeleteRangeAsyncCommandHandler(ILogger<DeleteRangeAsyncCommandHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Phone.Phone>>> Handle(DeleteRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}