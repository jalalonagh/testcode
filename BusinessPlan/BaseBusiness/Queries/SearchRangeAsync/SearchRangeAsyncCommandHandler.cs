using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.Cart.Command.SearchRangeAsync
{
    public class SearchRangeAsyncCommandHandler<TEntity, TDTO, TSearch, TKey> : ICommandHandler<SearchRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>, ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private readonly IBaseService<TEntity, TSearch> _service;
        private readonly ILogger<SearchRangeAsyncCommandHandler<TEntity, TDTO, TSearch, TKey>> _logger;

        public SearchRangeAsyncCommandHandler(ILogger<SearchRangeAsyncCommandHandler<TEntity, TDTO, TSearch, TKey>> logger, IBaseService<TEntity, TSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> Handle(SearchRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> request, CancellationToken cancel)
        {
            return await _service.SearchRangeAsync(request.Model);
        }
    }
}