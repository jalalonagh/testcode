using ManaEnums.Api;

namespace WebFramework.Api
{
    public interface IApiResult
    {
        ApiResult Generate(bool isSuccess, ApiResultStatus statusCode, string message = null);
    }

    public interface IApiResult<TData>
        where TData : class
    {
    }
}
