using Common;
using ManaEnums.Api;
using ManaEnums.Extensions;
using Newtonsoft.Json;

namespace WebFramework.Api
{
    public class ApiResult : IApiResult, ISingletonDependency
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public ApiResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }
        public ApiResult Generate(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            return this;
        }
    }
    public class ApiResult<TData> : ApiResult, IApiResult<TData>, ISingletonDependency
        where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }
        public ApiResult(bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }
    }
}
