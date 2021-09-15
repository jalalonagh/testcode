using ManaEnums.Api;
using ManaEnums.Extensions;

namespace Common.Models
{
    public class MethodResponseModel
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public MethodResponseModel(bool isSuccess, ApiResultStatus statusCode, object data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            Data = data;
        }

        public MethodResponseModel Generate(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            return this;
        }

    }
}
