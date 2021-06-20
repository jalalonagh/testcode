using BusinessBaseConfig.Configuration.Commands;
using Entities.SMS;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMSBusiness.BaseBusinessLevel.SMS.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandHandler : ICommandHandler<AddRangeAsyncCommand, ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        private readonly IBaseService<Entities.SMS.SMS, SMSSearch> _service;
        private readonly ILogger<AddRangeAsyncCommandHandler> _logger;

        public AddRangeAsyncCommandHandler(ILogger<AddRangeAsyncCommandHandler> logger, IBaseService<Entities.SMS.SMS, SMSSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMS.SMS>>> Handle(AddRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}