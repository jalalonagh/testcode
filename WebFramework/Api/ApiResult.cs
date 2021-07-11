using Common;
using Common.Utilities;
using ManaEnums.Api;
using ManaEnums.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WebFramework.Api
{
    public class ApiResult
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

        #region Implicit Operators
        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, ApiResultStatus.SUCCESS);
        }

        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, ApiResultStatus.BAD_REQUEST);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult(false, ApiResultStatus.BAD_REQUEST, message);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, ApiResultStatus.SUCCESS, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, ApiResultStatus.NOT_FOUND);
        }
        public static implicit operator ApiResult(UnauthorizedResult result)
        {
            return new ApiResult(false, ApiResultStatus.UNAUTHORIZED);
        }
        #endregion
    }

    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatus statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators
        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, ApiResultStatus.SUCCESS, data);
        }

        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatus.SUCCESS, null);
        }

        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatus.SUCCESS, (TData)result.Value);
        }

        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatus.BAD_REQUEST, null);
        }

        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult<TData>(false, ApiResultStatus.BAD_REQUEST, null, message);
        }

        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatus.SUCCESS, null, result.Content);
        }

        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatus.NOT_FOUND, null);
        }

        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatus.NOT_FOUND, (TData)result.Value);
        }
        public static implicit operator ApiResult<TData>(UnauthorizedObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatus.UNAUTHORIZED, (TData)result.Value);
        }
        #endregion
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
