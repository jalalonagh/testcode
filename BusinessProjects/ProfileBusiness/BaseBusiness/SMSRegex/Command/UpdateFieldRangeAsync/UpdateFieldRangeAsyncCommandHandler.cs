using BusinessLayout.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommandHandler : ICommandHandler<UpdateFieldRangeAsyncCommand, ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<UpdateFieldRangeAsyncCommandHandler> _logger;

        public UpdateFieldRangeAsyncCommandHandler(ILogger<UpdateFieldRangeAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSRegex.SMSRegex>> Handle(UpdateFieldRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeAsync(request.Model.ToEntity(), request.Fields);
        }
    }
}