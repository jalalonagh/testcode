using ManaBaseData.Repositories;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaSpeedTester;
using ManaSpeedTester.Models;
using Services.Base.Contracts;
using Services.Models;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Base.Services
{
    public class BaseService<TEntity, TSearchEntity> : IBaseService<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        public IRepository<TEntity, TSearchEntity> repository { get; set; }
        private TimeDurationTrackerSingleton tester;

        public BaseService(IRepository<TEntity, TSearchEntity> repository)
        {
            this.repository = repository;
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public async Task<IServiceResult<TEntity>> AddAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.AddAsync(entity);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
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

        public async Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteAsync(entity);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<TEntity>> DeleteByIdAsync(int id)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteByIdAsync(id);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), id));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
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

        public async Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
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

        public async Task<IServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
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

        public async Task<IServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
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

        public async Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.GetByIdAsync(ids);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await ItemSync(Target, Origin);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Target, Origin));      // SAVE SPEEDT TEST RESULT
            return result;
        }

        public async Task<IServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
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

        public async Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateAsync(entity);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateFieldRangeAsync(entity, fields);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity, fields));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateFieldRangeAsync(Id, fields);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Id, fields));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<IServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
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
