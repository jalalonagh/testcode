using ManaEnums.Api;
using ManaEnums.Extensions;
using Newtonsoft.Json;

namespace WebFramework.Api
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatus statusCode, object data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            Data = data;
        }

        public ApiResult Generate(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            return this;
        }
    }
}
