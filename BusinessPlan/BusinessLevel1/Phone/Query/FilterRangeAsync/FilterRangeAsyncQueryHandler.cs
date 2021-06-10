﻿using BusinessLayout.Configuration.Queries;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQueryHandler : IQueryHandler<FilterRangeAsyncQuery, ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<FilterRangeAsyncQueryHandler> _logger;

        public FilterRangeAsyncQueryHandler(ILogger<FilterRangeAsyncQueryHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Entities.Phone.Phone>>> Handle(FilterRangeAsyncQuery request, CancellationToken cancel)
        {
            return await _service.FilterRangeAsync(request.Model);
        }
    }
}