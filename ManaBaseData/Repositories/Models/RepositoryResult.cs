using ManaEnums.Api;
using ManaEnums.Extensions;

namespace Data.Repositories.Models
{
    public class RepositoryResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        public string Message { get; set; }

        public RepositoryResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }
    }

    public class RepositoryResult<TData> : RepositoryResult
        where TData : class
    {
        public TData Data { get; set; }

        public RepositoryResult(bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators
        public static implicit operator RepositoryResult<TData>(TData data)
        {
            return new RepositoryResult<TData>(true, ApiResultStatus.SUCCESS, data);
        }
        #endregion
    }
}
