﻿using BusinessLayout.Configuration.Commands;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommandHandler : ICommandHandler<DeleteRangeByIdsAsyncCommand, ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<DeleteRangeByIdsAsyncCommandHandler> _logger;

        public DeleteRangeByIdsAsyncCommandHandler(ILogger<DeleteRangeByIdsAsyncCommandHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>> Handle(DeleteRangeByIdsAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteRangeByIdsAsync(request.EntityIds);
        }
    }
}