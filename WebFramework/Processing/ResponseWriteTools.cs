using Common;
using ManaEnums.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Resolvers;

namespace WebFramework.Processing
{
    public class ResponseWriteTools : IResponseWriteTools, ISingletonDependency
    {
        public async Task<HttpContext> WriteToResponseAsync(HttpContext context, ApiResultStatus status, string message)
        {
            if (context.Response.HasStarted)
                throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");
            var result = new ApiResult(false, status, message);
            var settings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
            var json = JsonConvert.SerializeObject(result, Formatting.Indented, settings);
            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
            return context;
        }

        public void SetUnAuthorizeResponse(Exception exception, ApiResultStatus status, IWebHostEnvironment _env, out string message)
        {
            status = ApiResultStatus.UNAUTHORIZED;
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
            message = "";
        }
    }

    public interface IResponseWriteTools
    {
        Task<HttpContext> WriteToResponseAsync(HttpContext context, ApiResultStatus status, string message);
        void SetUnAuthorizeResponse(Exception exception, ApiResultStatus status, IWebHostEnvironment _env, out string message);
    }
}
