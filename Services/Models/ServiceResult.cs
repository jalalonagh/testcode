using ManaEnums.Api;
using ManaEnums.Extensions;

namespace Services.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        public string Message { get; set; }

        public ServiceResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }
    }

    public class ServiceResult<TData> : ServiceResult
        where TData : class
    {
        public TData Data { get; set; }

        public ServiceResult(bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        public TData GetData()
        {
            return Data;
        }

        public bool GetIsSuccess()
        {
            return IsSuccess;
        }

        public ApiResultStatus GetStatus()
        {
            return StatusCode;
        }

        public string GetMessage()
        {
            return Message;
        }

        public static implicit operator ServiceResult<TData>(TData data)
        {
            if (data == null)
                return new ServiceResult<TData>(false, ApiResultStatus.NOT_FOUND, null);
            return new ServiceResult<TData>(true, ApiResultStatus.SUCCESS, data);
        }
    }
}
