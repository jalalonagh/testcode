using BaseBusiness;
using Common;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaResourceManager;
using ManaViewModel.Common;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    //[ApiVersion("1")]
    public class GenericFilterController<TEntity, TValid, TSearch, TVM, TDTO, TKey> : BaseController
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearch : BaseSearchEntity, new()
        where TVM : BaseVM<TVM, TEntity, TKey>, new()
        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
        where TKey : struct
    {
        private IFilter<TEntity, TValid, TSearch, TDTO, TKey> crud;
        ResourceManagerSingleton resource;

        public GenericFilterController(IFilter<TEntity, TValid, TSearch, TDTO, TKey> _crud)
        {
            crud = _crud;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> FilterRangeAsync(FilterRangeModel<TSearch> model)
        {
            var result = await crud.FilterRangeAsync(model);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<TVM>>> SearchRangeAsync(SearchRangeModel<TEntity> model)
        {
            var result = await crud.SearchRangeAsync(model);
            var entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
    }
}