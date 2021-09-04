using ManaBaseData.Repositories;
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
    public class BaseRangeService<TEntity> : IBaseRangeService<TEntity>
        where TEntity : class, IEntity
    {
        public IRangeRepository<TEntity> repository { get; set; }
        private TimeDurationTrackerSingleton tester;

        public BaseRangeService(IRangeRepository<TEntity> repository)
        {
            this.repository = repository;
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public async Task<ServiceResult> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.AddRangeAsync(entities);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
        public async Task<ServiceResult> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteRangeAsync(entities);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
        public async Task<ServiceResult> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteRangeByIdsAsync(ids);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
        public async Task<ServiceResult> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.GetAllAsync(total, more);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), total, more));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
        public async Task<ServiceResult> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateRangeAsync(entities);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return true.GenerateResult(ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
    }
}
