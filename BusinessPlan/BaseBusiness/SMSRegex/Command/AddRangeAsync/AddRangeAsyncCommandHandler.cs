using BusinessLayout.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.AddRangeAsync
{
    public class AddRangeAsyncCommandHandler : ICommandHandler<AddRangeAsyncCommand, ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<AddRangeAsyncCommandHandler> _logger;

        public AddRangeAsyncCommandHandler(ILogger<AddRangeAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>> Handle(AddRangeAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddRangeAsync(request.Model.Select(s => s.ToEntity()));
        }
    }
}