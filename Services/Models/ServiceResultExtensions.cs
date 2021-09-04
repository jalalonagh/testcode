using ManaEnums.Api;

namespace Services.Models
{
    public static class ServiceResultExtensions
    {
        public static ServiceResult GenerateResult(this bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            return new ServiceResult(isSuccess, statusCode, message);
        }

        public static ServiceResult GenerateResult<TData>(this bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
        {
            return new ServiceResult(isSuccess, statusCode, data, message);
        }
    }
}
