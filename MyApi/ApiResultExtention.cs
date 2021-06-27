using ManaDataTransferObject.Common;
using ManaViewModel.Common;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
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

        public static ApiResult<TVM> ToApiResult<TEntity, TDTO, TVM, TKey>(this ServiceResult<TEntity> result)
            where TEntity : BaseEntity, new()
            where TVM : BaseVM<TVM, TEntity, TKey>, new()
            where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
            where TKey : struct
        {
            return new ApiResult<TVM>(result.IsSuccess, result.StatusCode, new TVM().DTOFromEntity(result.Data), result.Message);
        }

        public static ApiResult<IEnumerable<TVM>> ToApiResult<TEntity, TDTO, TVM, TKey>(this ServiceResult<IEnumerable<TEntity>> result)
            where TEntity : BaseEntity, new()
            where TVM : BaseVM<TVM, TEntity, TKey>, new()
            where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
            where TKey : struct
        {
            if (result == null || !result.IsSuccess || result.Data == null || !result.Data.Any())
                return new ApiResult<IEnumerable<TVM>>(result.IsSuccess, result.StatusCode, null, result.Message);

            return new ApiResult<IEnumerable<TVM>>(result.IsSuccess, result.StatusCode, result.Data.Select(s => new TVM().DTOFromEntity(s)), result.Message);
        }
    }
}
