//using BusinessLayout.Order.Commands.SyncSale;
//using BusinessLayout.Order.Commands.VerifyOrder;
//using BusinessPlan.Category;
//using Common.Utilities;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace MyApi.Controllers
//{
//    public class VerifyController : Controller
//    {
//        private readonly ICartHandler _cartHandler;
//        private readonly IMediator _mediator;
//        private readonly ILogger<VerifyController> _logger;

//        public VerifyController(
//           IMediator mediator,
//            ICartHandler cartHandler,
//            ILogger<VerifyController> logger
//            )
//        {
//            _cartHandler = cartHandler;
//            _mediator = mediator;
//            _cartHandler = cartHandler;
//            _logger = logger;
//        }

//        public async Task<IActionResult> Index(string authority, string status, bool mobile = false)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), User?.Identity?.Name, authority, status);
//            if (!string.IsNullOrEmpty(authority) && !string.IsNullOrEmpty(status))
//            {
//                var result = await _mediator.Send(new VerifyOrderCommand(authority, status));

//                if (result != null && result.IsSuccess)
//                {
//                    try
//                    {
//                        await _mediator.Send(new SyncSaleCommand());
//                    }
//                    catch (System.Exception exx)
//                    {
//                        Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), User?.Identity?.Name, exx);
//                    }

//                    var code = status == "OK" ? 100 : 500;
//                }

//                if (result != null && !result.IsSuccess && result.StatusCode == Common.ApiResultStatusCode.BadRequest)
//                {
//                }
//            }

//            return Redirect($"/?order={0}&authority={authority}&status={500}");
//        }

//        public IActionResult Close()
//        {
//            return View();
//        }
//    }
//}