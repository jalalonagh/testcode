using ManaEnums.Api;
using Services.Models;

namespace BaseBusiness.Models
{
    public static class ServiceResultExtensions
    {
        public static BusinessResult GenerateBusinessResult(this bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            return new BusinessResult(isSuccess, statusCode, message);
        }

        public static BusinessResult<TData> GenerateBusinessResult<TData>(this bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
            where TData : class
        {
            return new BusinessResult<TData>(isSuccess, statusCode, data, message);
        }

        public static BusinessResult<TData> ToBusinessResult<TData>(this ServiceResult<TData> result)
            where TData : class
        {
            return new BusinessResult<TData>(result?.GetIsSuccess() ?? false, result?.GetStatus() ?? ApiResultStatus.BAD_REQUEST, result?.GetData() ?? null, result?.GetMessage() ?? "");
        }
    }
}
