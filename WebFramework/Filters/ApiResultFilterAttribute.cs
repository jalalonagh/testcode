using Common;
using ManaEnums.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using WebFramework.Api;

namespace WebFramework.Filters
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult okObjectResult)
            {
                var apiResult = new ApiResult<object>(true, ApiResultStatus.SUCCESS, okObjectResult.Value);
                context.Result = new JsonResult(apiResult) { StatusCode = okObjectResult.StatusCode };
            }
            else if (context.Result is OkResult okResult)
            {
                var apiResult = new ApiResult(true, ApiResultStatus.SUCCESS);
                context.Result = new JsonResult(apiResult) { StatusCode = okResult.StatusCode };
            }
            else if (context.Result is BadRequestResult badRequestResult)
            {
                var apiResult = new ApiResult(false, ApiResultStatus.BAD_REQUEST);
                context.Result = new JsonResult(apiResult) { StatusCode = badRequestResult.StatusCode };
            }
            else if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                var message = badRequestObjectResult.Value.ToString();

                System.Reflection.PropertyInfo pi = badRequestObjectResult.Value.GetType().GetProperty("Errors");

                Dictionary<string, string[]> errors = (Dictionary<string, string[]>)(pi.GetValue(badRequestObjectResult.Value, null));

                var errorMessage = errors.SelectMany(p => p.Value).Distinct();
                message = string.Join(" | ", errorMessage);

                var apiResult = new ApiResult(false, ApiResultStatus.BAD_REQUEST, message);
                context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
            }
            else if (context.Result is ContentResult contentResult)
            {
                var apiResult = new ApiResult(true, ApiResultStatus.SUCCESS, contentResult.Content);
                context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
            }
            else if (context.Result is NotFoundResult notFoundResult)
            {
                var apiResult = new ApiResult(false, ApiResultStatus.NOT_FOUND);
                context.Result = new JsonResult(apiResult) { StatusCode = notFoundResult.StatusCode };
            }
            else if (context.Result is NotFoundObjectResult notFoundObjectResult)
            {
                var apiResult = new ApiResult<object>(false, ApiResultStatus.NOT_FOUND, notFoundObjectResult.Value);
                context.Result = new JsonResult(apiResult) { StatusCode = notFoundObjectResult.StatusCode };
            }
            else if (context.Result is ObjectResult objectResult && objectResult.StatusCode == null
                && !(objectResult.Value is ApiResult))
            {
                var apiResult = new ApiResult<object>(true, ApiResultStatus.SUCCESS, objectResult.Value);
                context.Result = new JsonResult(apiResult) { StatusCode = objectResult.StatusCode };
            }

            base.OnResultExecuting(context);
        }
    }
}
