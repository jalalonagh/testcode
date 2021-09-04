using BaseBusiness;
using BaseBusiness.Models;
using Common;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
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
    public class GenericFilterController<TEntity, TValid, TSearch, TVM> : BaseController
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearch : BaseSearchEntity, new()
        where TVM : BaseVM<TVM, TEntity, int>, new()
    {
        private IFilter<TEntity, TValid, TSearch> crud;
        ResourceManagerSingleton resource;

        public GenericFilterController(IFilter<TEntity, TValid, TSearch> _crud)
        {
            crud = _crud;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<ApiResult> FilterRangeAsync(FilterRangeModel<TSearch> model)
        {
            var result = await crud.FilterRangeAsync(model);
            var entities = result.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult> SearchRangeAsync(SearchRangeModel<TEntity> model)
        {
            var result = await crud.SearchRangeAsync(model);
            var entities = result.MapTo<BusinessResult<IEnumerable<TVM>>>();
            return entities.ToApiResult();
        }
    }
}