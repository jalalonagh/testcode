using Common.Exceptions;
using ManaEnums.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebFramework.Processing;
using WebFramework.Resolvers;

namespace WebFramework.MiddleWares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly IResponseWriteTools _response;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<CustomExceptionHandlerMiddleware> logger, IResponseWriteTools response)
        {
            _next = next;
            _env = env;
            _logger = logger;
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
                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                    }
                    var settings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
                    if (exception.AdditionalData != null)
                        dic.Add("AdditionalData",
                            JsonConvert.SerializeObject(exception.AdditionalData, Formatting.Indented, settings));
                    message = JsonConvert.SerializeObject(dic, Formatting.Indented, settings);
                }
                else
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
                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    var settings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
                    message = JsonConvert.SerializeObject(dic, Formatting.Indented, settings);
                }
                context = await _response.WriteToResponseAsync(context, apiStatusCode, message);
            }
        }
    }
}