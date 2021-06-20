using BusinessBaseConfig.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.UpdateAsync
{
    public class UpdateAsyncCommandHandler : ICommandHandler<UpdateAsyncCommand, ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<UpdateAsyncCommandHandler> _logger;

        public UpdateAsyncCommandHandler(ILogger<UpdateAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSRegex.SMSRegex>> Handle(UpdateAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateAsync(request.Model.ToEntity());
        }
    }
}