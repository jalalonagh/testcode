using Common;
using ManaEnums.Api;
using ManaEnums.Extensions;
using Services.Models;

namespace BaseBusiness.Models
{
    public class BusinessResult : IBusinessResult, ISingletonDependency
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        public string Message { get; set; }

        public BusinessResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        public void FromServiceResult(ServiceResult result)
        {
            IsSuccess = result?.IsSuccess ?? false;
            StatusCode = result?.StatusCode ?? ApiResultStatus.BAD_REQUEST;
            Message = result?.Message ?? "";
        }
    }

    public class BusinessResult<TData> : BusinessResult, IBusinessResult<TData>, ISingletonDependency
        where TData : class
    {
        public TData Data { get; set; }

        public BusinessResult(bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
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

        public void FromServiceResult(ServiceResult<TData> result)
        {
            IsSuccess = result?.IsSuccess ?? false;
            StatusCode = result?.StatusCode ?? ApiResultStatus.BAD_REQUEST;
            Message = result?.Message ?? "";
            Data = result?.Data ?? null;
        }

        public static implicit operator BusinessResult<TData>(TData data)
        {
            if (data == null)
                return new BusinessResult<TData>(false, ApiResultStatus.NOT_FOUND, null);
            return new BusinessResult<TData>(true, ApiResultStatus.SUCCESS, data);
        }
    }
}
