using ManaEnums.Api;
using ManaEnums.Extensions;
using Services.Models;

namespace BaseBusiness.Models
{
    public class BusinessResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public BusinessResult()
        {

        }

        public BusinessResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        public BusinessResult(bool isSuccess, ApiResultStatus statusCode, object data, string message = null)
        {
            Data = data;
        }

        public object Geobject()
        {
            return Data;
        }

        public bool GetIsSuccess()
        {
            return IsSuccess;
        }

        public void FromServiceResult(ServiceResult result)
        {
            IsSuccess = result?.IsSuccess ?? false;
            StatusCode = result?.StatusCode ?? ApiResultStatus.BAD_REQUEST;
            Message = result?.Message ?? "";
            Data = result?.Data ?? null;
        }
    }

    public class BusinessResult<T> : BusinessResult
    {
        new public T Data { get; set; }

        public BusinessResult(bool isSuccess, ApiResultStatus statusCode, T data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
