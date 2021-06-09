using BusinessLayout.Configuration.Queries;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusiness.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQueryHandler<TEntity, TDTO, TSearch, TKey> : IQueryHandler<SearchRangeAsyncQuery<TEntity, TDTO, TSearch, TKey>, ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private readonly IBaseService<TEntity, TSearch> _service;
        private readonly ILogger<SearchRangeAsyncQueryHandler<TEntity, TDTO, TSearch, TKey>> _logger;

        public SearchRangeAsyncQueryHandler(ILogger<SearchRangeAsyncQueryHandler<TEntity, TDTO, TSearch, TKey>> logger, IBaseService<TEntity, TSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> Handle(SearchRangeAsyncQuery<TEntity, TDTO, TSearch, TKey> request, CancellationToken cancel)
        {
            return await _service.SearchRangeAsync(request.Model);
        }
    }
}