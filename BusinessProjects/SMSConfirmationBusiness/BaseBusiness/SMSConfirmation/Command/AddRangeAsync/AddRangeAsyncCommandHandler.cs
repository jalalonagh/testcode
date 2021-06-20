using BusinessBaseConfig.Configuration.Commands;
using Entities.SMSConfirmation;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandHandler : ICommandHandler<AddRangeAsyncCommand, ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        private readonly IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> _service;
        private readonly ILogger<AddRangeAsyncCommandHandler> _logger;

        public AddRangeAsyncCommandHandler(ILogger<AddRangeAsyncCommandHandler> logger, IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>> Handle(AddRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}