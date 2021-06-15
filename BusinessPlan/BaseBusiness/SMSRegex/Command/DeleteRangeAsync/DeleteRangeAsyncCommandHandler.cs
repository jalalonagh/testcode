using BusinessLayout.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteRangeAsync
{
    public class DeleteRangeAsyncCommandHandler : ICommandHandler<DeleteRangeAsyncCommand, ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<DeleteRangeAsyncCommandHandler> _logger;

        public DeleteRangeAsyncCommandHandler(ILogger<DeleteRangeAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>> Handle(DeleteRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}