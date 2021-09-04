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

        public static BusinessResult GenerateBusinessResult(this bool isSuccess, ApiResultStatus statusCode, object data, string message = null)
        {
            return new BusinessResult(isSuccess, statusCode, data, message);
        }

        public static BusinessResult ToBusinessResult(this ServiceResult result)
        {
            return new BusinessResult(result?.GetIsSuccess() ?? false, result?.GetStatus() ?? ApiResultStatus.BAD_REQUEST, result?.GetData() ?? null, result?.GetMessage() ?? "");
        }
    }
}
