using BusinessLayout.Configuration.Queries;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusiness.Query.GetByIdAsync
{
    public class GetByIdAsyncQueryHandler<TEntity, TDTO, TSearch, TKey> : IQueryHandler<GetByIdAsyncQuery<TEntity, TDTO, TSearch, TKey>, ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private readonly IBaseService<TEntity, TSearch> _service;
        private readonly ILogger<GetByIdAsyncQueryHandler<TEntity, TDTO, TSearch, TKey>> _logger;

        public GetByIdAsyncQueryHandler(ILogger<GetByIdAsyncQueryHandler<TEntity, TDTO, TSearch, TKey>> logger, IBaseService<TEntity, TSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<TEntity>> Handle(GetByIdAsyncQuery<TEntity, TDTO, TSearch, TKey> request, CancellationToken cancel)
        {
            return await _service.GetByIdAsync(request.EntityIds);
        }
    }
}