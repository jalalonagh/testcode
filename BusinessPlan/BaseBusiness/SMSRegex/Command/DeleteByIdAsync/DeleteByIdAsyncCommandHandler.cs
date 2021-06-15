using BusinessLayout.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandHandler : ICommandHandler<DeleteByIdAsyncCommand, ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<DeleteByIdAsyncCommandHandler> _logger;

        public DeleteByIdAsyncCommandHandler(ILogger<DeleteByIdAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSRegex.SMSRegex>> Handle(DeleteByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteByIdAsync(request.EntityId);
        }
    }
}