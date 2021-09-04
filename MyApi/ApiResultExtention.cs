using BaseBusiness.Models;
using Services.Models;
using WebFramework.Api;

namespace MyApi
{
    public static class ApiResultExtention
    {
        public static ApiResult ToApiResult(this ServiceResult result)
        {
            return new WebFramework.Api.ApiResult(result.IsSuccess, result.StatusCode, result.Data, result.Message);
        }

        public static ApiResult ToApiResult(this BusinessResult result)
        {
            return new WebFramework.Api.ApiResult(result.IsSuccess, result.StatusCode, result.Data, result.Message);
        }
    }
}
