using ManaBaseData.Repositories;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaSpeedTester;
using ManaSpeedTester.Models;
using Services.Base.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Base.Services
{
    public class BaseFilterService<TEntity, TSearchEntity> : IBaseFilterService<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        public IFilterRepository<TEntity, TSearchEntity> repository { get; set; }
        private TimeDurationTrackerSingleton tester;

        public BaseFilterService(IFilterRepository<TEntity, TSearchEntity> repository)
        {
            this.repository = repository;
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.FilterRangeAsync(filter);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), filter));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
        public async Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await ItemSync(Target, Origin);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Target, Origin));      // SAVE SPEEDT TEST RESULT
            return result;
        }
        public async Task<ServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.SearchRangeAsync(search);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), search));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
    }
}
