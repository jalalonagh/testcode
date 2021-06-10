using BusinessLayout.Configuration.Commands;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommandHandler : ICommandHandler<UpdateRangeAsyncCommand, ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<UpdateRangeAsyncCommandHandler> _logger;

        public UpdateRangeAsyncCommandHandler(ILogger<UpdateRangeAsyncCommandHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Phone.Phone>>> Handle(UpdateRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}