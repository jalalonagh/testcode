using ManaEnums.Api;
using ManaEnums.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WebFramework.Api
{
    public class ApiResult : IApiResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        public ApiResult Generate(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            return this;
        }
    }

    public class ApiResult<TData> : ApiResult, IApiResult<TData>
        where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }
    }

    public class ApiStructResult<TStruct> : ApiResult
        where TStruct : struct
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TStruct Data { get; set; }

        public ApiStructResult(bool isSuccess, ApiResultStatus statusCode, TStruct data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators
        public static implicit operator ApiStructResult<TStruct>(TStruct data)
        {
            return new ApiStructResult<TStruct>(true, ApiResultStatus.SUCCESS, data);
        }

        public static implicit operator ApiStructResult<TStruct>(OkResult result)
        {
            return new ApiStructResult<TStruct>(true, ApiResultStatus.SUCCESS, default(TStruct));
        }

        public static implicit operator ApiStructResult<TStruct>(OkObjectResult result)
        {
            return new ApiStructResult<TStruct>(true, ApiResultStatus.SUCCESS, (TStruct)result.Value);
        }

        public static implicit operator ApiStructResult<TStruct>(BadRequestResult result)
        {
            return new ApiStructResult<TStruct>(false, ApiResultStatus.BAD_REQUEST, default(TStruct));
        }

        public static implicit operator ApiStructResult<TStruct>(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiStructResult<TStruct>(false, ApiResultStatus.BAD_REQUEST, default(TStruct), message);
        }

        public static implicit operator ApiStructResult<TStruct>(ContentResult result)
        {
            return new ApiStructResult<TStruct>(true, ApiResultStatus.SUCCESS, default(TStruct), result.Content);
        }

        public static implicit operator ApiStructResult<TStruct>(NotFoundResult result)
        {
            return new ApiStructResult<TStruct>(false, ApiResultStatus.NOT_FOUND, default(TStruct));
        }

        public static implicit operator ApiStructResult<TStruct>(NotFoundObjectResult result)
        {
            return new ApiStructResult<TStruct>(false, ApiResultStatus.NOT_FOUND, (TStruct)result.Value);
        }
        public static implicit operator ApiStructResult<TStruct>(UnauthorizedObjectResult result)
        {
            return new ApiStructResult<TStruct>(false, ApiResultStatus.UNAUTHORIZED, (TStruct)result.Value);
        }
        #endregion
    }
}
