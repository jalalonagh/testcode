using BusinessLayout.BaseBusiness.Command.DeleteAsync;
using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteAsync
{
    public class DeleteAsyncCommandHandler<TEntity, TDTO, TSearch, TKey> : ICommandHandler<DeleteAsyncCommand<TEntity, TDTO, TSearch, TKey>, ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private readonly IBaseService<TEntity, TSearch> _service;
        private readonly ILogger<DeleteAsyncCommandHandler<TEntity, TDTO, TSearch, TKey>> _logger;

        public DeleteAsyncCommandHandler(ILogger<DeleteAsyncCommandHandler<TEntity, TDTO, TSearch, TKey>> logger, IBaseService<TEntity, TSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<TEntity>> Handle(DeleteAsyncCommand<TEntity, TDTO, TSearch, TKey> request, CancellationToken cancel)
        {
            return await _service.DeleteAsync(request.Model.ToEntity());
        }
    }
}