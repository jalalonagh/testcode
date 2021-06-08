using BusinessLayout.Cart.Command.AddAsync;
using Common.Utilities;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using ManaViewModel.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class BaseBusinessController<TEntity, TDTO, TVM, TSearch, TKey> : BaseController
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TVM : BaseVM<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        private IMediator mediator;

        public BaseBusinessController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<TVM>> AddAsync(TDTO model)
        {
            var result = await mediator.Send(new AddAsyncCommand<TEntity, TDTO, TSearch, TKey>(model));
            TDTO data =;
            return result.ToApiResult();
        }

        //[HttpPost("[action]")]
        //public async Task<ApiResult> IncreaseCredit([FromBody] WalletSurvayDto model)
        //{
        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username, model);
        //    var result = await _walletHandler.IncreaseCredit(model.Value, Username);
        //    return result.ToApiResult();
        //}

        //[HttpPost("[action]")]
        //public async Task<ApiResult> PayWithWallet([FromBody] WalletSurvayDto model)
        //{
        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username, model);
        //    var result = await _walletHandler.PayWithWallet(model.Value, Username);
        //    return result.ToApiResult();
        //}

        //[HttpPost("[action]")]
        //public async Task<ApiResult<WalletVM>> CreateWallet()
        //{
        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username);
        //    var result = await _walletHandler.CreateWallet(Username);
        //    return result.ToApiResult();
        //}

        //[HttpPost("[action]")]
        //public async Task<ApiResult<WalletVM>> GetWallet()
        //{
        //    Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username);
        //    var result = await _walletHandler.GetWallet(Username);
        //    return result.ToApiResult();
        //}
    }
}