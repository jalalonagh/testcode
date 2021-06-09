using BusinessLayout.Cart.Command.FilterRangeAsync;
using BusinessLayout.Cart.Command.GetAllAsync;
using BusinessLayout.Cart.Command.GetByIdAsync;
using BusinessLayout.Cart.Command.SearchRangeAsync;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using ManaDataTransferObject.Common;
using ManaViewModel.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class BaseBusinessQueryController<TEntity, TDTO, TVM, TSearch, TKey> : BaseController
        where TEntity : BaseEntity, new()
        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
        where TVM : BaseVM<TVM, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        private IMediator mediator;

        public BaseBusinessQueryController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> FilterRangeAsync(FilterRangeModel<TSearch> model)
        {
            var result = await mediator.Send(new FilterRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>(model));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await new GetAllAsyncCommandHandler<TEntity, TDTO, TVM, TKey>().Handle(new GetAllAsyncCommand<TEntity, TDTO, TSearch, TKey>(total, more));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<TVM>>> SearchRangeAsync(SearchRangeModel<TEntity> model)
        {
            var result = await mediator.Send(new SearchRangeAsyncCommand<TEntity, TDTO, TSearch, TKey>(model));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<TVM>> GetByIdAsync(int[] ids)
        {
            var result = await mediator.Send(new GetByIdAsyncCommand<TEntity, TDTO, TSearch, TKey>(ids));
            return result.ToApiResult<TEntity, TDTO, TVM, TKey>();
        }
    }
}