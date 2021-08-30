using ManaEnums.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
