using ManaEnums.Api;

namespace WebFramework.Api
{
    public static class ApiResultExtensions
    {
        public static ApiResult Generate(this bool isSuccess, ApiResultStatus status, object data, string message)
        {
            return new ApiResult(isSuccess, status, data, message);
        }

        public static ApiResult Generate(this object data, bool isSuccess, ApiResultStatus status, string message)
        {
            if (data == null)
                return new ApiResult(isSuccess, status, data, message);
            return new ApiResult(true, ApiResultStatus.SUCCESS, data);
        }
    }
}
