using Common;
using Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessLayout.Configuration.Validation;
using FluentValidation;
using WebFramework.Api;
using ManaEnums.Api;

namespace WebFramework.MiddleWares
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var t = propertyName.ToCharArray().ToList();

            return t[0].ToString().ToLowerInvariant() + string.Join(string.Empty, t.Skip(1));
        }
    }

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next,
                                                IWebHostEnvironment env,
                                                ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
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
                _logger.LogError(exception, exception.Message);
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

                    var settings = new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};

                    if (exception.AdditionalData != null)
                        dic.Add("AdditionalData",
                            JsonConvert.SerializeObject(exception.AdditionalData, Formatting.Indented, settings));

                    message = JsonConvert.SerializeObject(dic, Formatting.Indented, settings);
                }
                else
                {
                    message = exception.Message;
                }

                await WriteToResponseAsync();
            }
            catch (SecurityTokenExpiredException exception)
            {
                _logger.LogError(exception, exception.Message);
                SetUnAuthorizeResponse(exception);
                await WriteToResponseAsync();
            }
            catch (UnauthorizedAccessException exception)
            {
                _logger.LogError(exception, exception.Message);
                SetUnAuthorizeResponse(exception);
                await WriteToResponseAsync();
            }
            catch (Exception exception)
            {
               _logger.LogError(exception, exception.Message);

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
                await WriteToResponseAsync();
            }

            async Task WriteToResponseAsync()
            {
                if (context.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

                var result = new ApiResult(false, apiStatusCode, message);

                var settings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };

                var json = JsonConvert.SerializeObject(result, Formatting.Indented, settings);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }

            void SetUnAuthorizeResponse(Exception exception)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                apiStatusCode = ApiResultStatus.UNAUTHORIZED;

                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace
                    };
                    if (exception is SecurityTokenExpiredException tokenException)
                        dic.Add("Expires", tokenException.Expires.ToString());
                    var settings = new JsonSerializerSettings();
                    settings.ContractResolver = new LowercaseContractResolver();
                    message = JsonConvert.SerializeObject(dic, Formatting.Indented, settings);
                }
            }
        }
    }
}