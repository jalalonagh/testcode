//using BusinessLayout.Wallet;
//using BusinessLayout.Wallet.Share.ViewModels;
//using Common.Utilities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Threading.Tasks;
//using WebFramework.Api;

//namespace MyApi.Controllers.Api.v1
//{
//    [ApiVersion("1")]
//    [AllowAnonymous]
//    public class WalletController : BaseController
//    {
//        private readonly IWalletHandler _walletHandler;
//        private readonly ILogger<WalletController> _logger;

//        public WalletController(IWalletHandler walletHandler, ILogger<WalletController> logger)
//        {
//            _walletHandler = walletHandler;
//            _logger = logger;
//        }

//        [HttpGet("[action]")]
//        public async Task<IEnumerable<WalletSurvayVM>> GetWalletSurvay([FromBody] WalletSurvayDto model)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username, model);
//            var survey = await _walletHandler.GetWalletSurvay(model.Value, Username);
//            return survey.IsSuccess ? survey.Data : new List<WalletSurvayVM>();
//        }

//        [HttpPost("[action]")]
//        public async Task<ApiResult> IncreaseCredit([FromBody] WalletSurvayDto model)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username, model);
//            var result = await _walletHandler.IncreaseCredit(model.Value, Username);
//            return result.ToApiResult();
//        }

//        [HttpPost("[action]")]
//        public async Task<ApiResult> PayWithWallet([FromBody] WalletSurvayDto model)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username, model);
//            var result = await _walletHandler.PayWithWallet(model.Value, Username);
//            return result.ToApiResult();
//        }

//        [HttpPost("[action]")]
//        public async Task<ApiResult<WalletVM>> CreateWallet()
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username);
//            var result = await _walletHandler.CreateWallet(Username);
//            return result.ToApiResult();
//        }

//        [HttpPost("[action]")]
//        public async Task<ApiResult<WalletVM>> GetWallet()
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), Username);
//            var result = await _walletHandler.GetWallet(Username);
//            return result.ToApiResult();
//        }
//    }
//}