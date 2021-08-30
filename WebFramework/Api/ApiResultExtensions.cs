using ManaEnums.Api;

namespace WebFramework.Api
{
    public static class ApiResultExtensions
    {
        public static ApiResult<TData> Generate<TData>(this bool isSuccess)
            where TData : class
        {
            if (isSuccess)
                return new ApiResult<TData>(isSuccess, ApiResultStatus.SUCCESS, null);
            return new ApiResult<TData>(isSuccess, ApiResultStatus.NOT_FOUND, null);
        }

        public static ApiResult<TData> Generate<TData>(this bool isSuccess, ApiResultStatus status)
            where TData : class
        {
            return new ApiResult<TData>(isSuccess, status, null);
        }

        public static ApiResult<TData> Generate<TData>(this bool isSuccess, ApiResultStatus status, TData data)
            where TData : class
        {
            return new ApiResult<TData>(isSuccess, status, data);
        }

        public static ApiResult<TData> Generate<TData>(this bool isSuccess, ApiResultStatus status, TData data, string message)
            where TData : class
        {
            return new ApiResult<TData>(isSuccess, status, data, message);
        }

        public static ApiResult<TData> Generate<TData>(this TData data)
            where TData : class
        {
            if (data == null)
                return new ApiResult<TData>(false, ApiResultStatus.NOT_FOUND, data);
            return new ApiResult<TData>(true, ApiResultStatus.SUCCESS, data);
        }

        public static ApiResult<TData> Generate<TData>(TData data, string message)
            where TData : class
        {
            if (data == null)
                return new ApiResult<TData>(false, ApiResultStatus.NOT_FOUND, data, message);
            return new ApiResult<TData>(true, ApiResultStatus.SUCCESS, data, message);
        }

        public static ApiResult<TData> Generate<TData>(TData data, ApiResultStatus status)
            where TData : class
        {
            if (data == null)
                return new ApiResult<TData>(false, status, data);
            return new ApiResult<TData>(true, status, data);
        }

        public static ApiResult<TData> Generate<TData>(TData data, ApiResultStatus status, string message)
            where TData : class
        {
            if (data == null)
                return new ApiResult<TData>(false, status, data, message);
            return new ApiResult<TData>(true, status, data, message);
        }

        public static ApiResult<TData> Generate<TData>(TData data, ApiResultStatus status, bool isSuccess)
            where TData : class
        {
            return new ApiResult<TData>(isSuccess, status, data);
        }

        public static ApiResult<TData> Generate<TData>(TData data, ApiResultStatus status, bool isSuccess, string message)
            where TData : class
        {
            return new ApiResult<TData>(isSuccess, status, data, message);
        }
    }
}
