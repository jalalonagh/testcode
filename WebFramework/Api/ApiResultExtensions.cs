using ManaEnums.Api;

namespace WebFramework.Api
{
    public static class ApiResultExtensions
    {
        public static ApiResult Generate(this bool isSuccess)
        {
            if (isSuccess)
                return new ApiResult(isSuccess, ApiResultStatus.SUCCESS, null);
            return new ApiResult(isSuccess, ApiResultStatus.NOT_FOUND, null);
        }

        public static ApiResult Generate(this bool isSuccess, ApiResultStatus status)
        {
            return new ApiResult(isSuccess, status, null);
        }

        public static ApiResult Generate(this bool isSuccess, ApiResultStatus status, object data)
        {
            return new ApiResult(isSuccess, status, data);
        }

        public static ApiResult Generate(this bool isSuccess, ApiResultStatus status, object data, string message)
        {
            return new ApiResult(isSuccess, status, data, message);
        }

        public static ApiResult Generate(this object data)
        {
            if (data == null)
                return new ApiResult(false, ApiResultStatus.NOT_FOUND, data);
            return new ApiResult(true, ApiResultStatus.SUCCESS, data);
        }

        public static ApiResult Generate(object data, string message)
        {
            if (data == null)
                return new ApiResult(false, ApiResultStatus.NOT_FOUND, data, message);
            return new ApiResult(true, ApiResultStatus.SUCCESS, data, message);
        }

        public static ApiResult Generate(object data, ApiResultStatus status)
        {
            if (data == null)
                return new ApiResult(false, status, data);
            return new ApiResult(true, status, data);
        }

        public static ApiResult Generate(object data, ApiResultStatus status, string message)
        {
            if (data == null)
                return new ApiResult(false, status, data, message);
            return new ApiResult(true, status, data, message);
        }

        public static ApiResult Generate(object data, ApiResultStatus status, bool isSuccess)
        {
            return new ApiResult(isSuccess, status, data);
        }

        public static ApiResult Generate(object data, ApiResultStatus status, bool isSuccess, string message)
        {
            return new ApiResult(isSuccess, status, data, message);
        }
    }
}
