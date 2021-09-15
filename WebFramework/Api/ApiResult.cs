using Common.Models;
using ManaEnums.Api;
using ManaEnums.Extensions;

namespace WebFramework.Api
{
    public class ApiResult : MethodResponseModel
    {
        public ApiResult(bool isSuccess, ApiResultStatus statusCode, object data, string message = null): base(isSuccess, statusCode, data, message)
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
