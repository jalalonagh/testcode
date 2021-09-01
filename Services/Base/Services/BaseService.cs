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
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, IEntity
    {
        public IRepository<TEntity> repository { get; set; }
        private TimeDurationTrackerSingleton tester;

        public BaseService(IRepository<TEntity> repository)
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
        public async Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await repository.GetByIdAsync(ids);
            tester.SaveServiceSpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            return result.ToServiceResult();
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
    }
}
