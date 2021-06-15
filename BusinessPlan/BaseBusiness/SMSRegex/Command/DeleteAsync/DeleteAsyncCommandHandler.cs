using BusinessLayout.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteAsync
{
    public class DeleteAsyncCommandHandler : ICommandHandler<DeleteAsyncCommand, ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<DeleteAsyncCommandHandler> _logger;

        public DeleteAsyncCommandHandler(ILogger<DeleteAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSRegex.SMSRegex>> Handle(DeleteAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteAsync(request.Model.ToEntity());
        }
    }
}