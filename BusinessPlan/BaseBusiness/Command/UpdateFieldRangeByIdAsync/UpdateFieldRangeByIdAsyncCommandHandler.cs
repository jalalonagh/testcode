using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusiness.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandHandler<TEntity, TDTO, TSearch, TKey> : ICommandHandler<UpdateFieldRangeByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>, ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private readonly IBaseService<TEntity, TSearch> _service;
        private readonly ILogger<UpdateFieldRangeByIdAsyncCommandHandler<TEntity, TDTO, TSearch, TKey>> _logger;

        public UpdateFieldRangeByIdAsyncCommandHandler(ILogger<UpdateFieldRangeByIdAsyncCommandHandler<TEntity, TDTO, TSearch, TKey>> logger, IBaseService<TEntity, TSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<TEntity>> Handle(UpdateFieldRangeByIdAsyncCommand<TEntity, TDTO, TSearch, TKey> request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeByIdAsync(request.EntityId, request.Fields);
        }
    }
}