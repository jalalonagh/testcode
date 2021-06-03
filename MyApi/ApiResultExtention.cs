using Services;
using WebFramework.Api;

namespace MyApi
{
    public static class ApiResultExtention
    {
        public static ApiResult ToApiResult(this ServiceResult result)
        {
            return new WebFramework.Api.ApiResult(result.IsSuccess, result.StatusCode, result.Message);
        }
        public static ApiResult<TData> ToApiResult<TData>(this ServiceResult<TData> result) where TData : class
        {
            return new WebFramework.Api.ApiResult<TData>(result.IsSuccess, result.StatusCode, result.Data, result.Message);
        }
    }
}
