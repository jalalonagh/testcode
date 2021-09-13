using Common.Exceptions;
using ManaEnums.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Threading.Tasks;
using WebFramework.Processing;

namespace WebFramework.MiddleWares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly IResponseWriteTools _response;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env, IResponseWriteTools response)
        {
            _next = next;
            _env = env;
            _response = response;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = null;
            var httpStatusCode = HttpStatusCode.InternalServerError;
            var apiStatusCode = ApiResultStatus.SERVER_ERROR;
            try
            {
                await _next(context);
            }
            catch (AppException exception)
            {
                httpStatusCode = exception.HttpStatusCode;
                apiStatusCode = exception.ApiStatusCode;
                message = exception.Message;
                context = await _response.WriteToResponseAsync(context, apiStatusCode, message);
            }
            catch (SecurityTokenExpiredException exception)
            {
                _response.SetUnAuthorizeResponse(exception, apiStatusCode, _env, out message);
                context = await _response.WriteToResponseAsync(context, apiStatusCode, message);
            }
            catch (UnauthorizedAccessException exception)
            {
                _response.SetUnAuthorizeResponse(exception, apiStatusCode, _env, out message);
                context = await _response.WriteToResponseAsync(context, apiStatusCode, message);
            }
            catch (Exception exception)
            {
                context = await _response.WriteToResponseAsync(context, apiStatusCode, message);
            }
        }
    }
}