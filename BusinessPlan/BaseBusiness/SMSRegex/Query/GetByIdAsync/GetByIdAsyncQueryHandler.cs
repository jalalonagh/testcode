﻿using BusinessLayout.Configuration.Queries;
using Entities.SMSRegex;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryHandler : IQueryHandler<GetByIdAsyncQuery, ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        private readonly IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> _service;
        private readonly ILogger<GetByIdAsyncQueryHandler> _logger;

        public GetByIdAsyncQueryHandler(ILogger<GetByIdAsyncQueryHandler> logger, IBaseService<Entities.SMSRegex.SMSRegex, SMSRegexSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSRegex.SMSRegex>> Handle(GetByIdAsyncQuery request, CancellationToken cancel)
        {
            return await _service.GetByIdAsync(request.EntityIds);
        }
    }
}