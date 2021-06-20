using BusinessBaseConfig.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.AddAsync
{
    public class AddAsyncCommandHandler : ICommandHandler<AddAsyncCommand, ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<AddAsyncCommandHandler> _logger;

        public AddAsyncCommandHandler(ILogger<AddAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSRegex.SMSRegex>> Handle(AddAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddAsync(request.Model.ToEntity());
        }
    }
}