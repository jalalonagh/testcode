using Data.Repositories.Models;
using Services.Models;

namespace Services.Tools
{
    public static class RepositoryResultExtention
    {
        public static ServiceResult ToServiceResult(this RepositoryResult result)
        {
            return new ServiceResult(result.IsSuccess, result.StatusCode, result.Message);
        }
        public static ServiceResult ToServiceResult<TData>(this RepositoryResult<TData> result) where TData : class
        {
            return new ServiceResult(result.IsSuccess, result.StatusCode, result.Data, result.Message);
        }
    }
}
