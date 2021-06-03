using Data.Repositories;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaSpeedTester;
using ManaSpeedTester.Models;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

        public async Task<ServiceResult<TEntity>> AddAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.AddAsync(entity);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.AddRangeAsync(entities);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteAsync(entity);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> DeleteByIdAsync(int id)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteByIdAsync(id);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), id));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteRangeAsync(entities);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.DeleteRangeByIdsAsync(ids);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.FilterRangeAsync(filter);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), filter));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.GetAllAsync(total, more);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), total, more));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.GetByIdAsync(ids);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await ItemSync(Target, Origin);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Target, Origin));      // SAVE SPEEDT TEST RESULT
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.SearchRangeAsync(search);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), search));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateAsync(entity);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateFieldRangeAsync(entity, fields);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity, fields));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateFieldRangeAsync(Id, fields);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Id, fields));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.UpdateRangeAsync(entities);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");
            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");
            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
    }
}
