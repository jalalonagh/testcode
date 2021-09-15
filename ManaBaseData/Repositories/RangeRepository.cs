using Common.Utilities;
using Data;
using Data.Repositories.Models;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaResourceManager;
using ManaSpeedTester;
using ManaSpeedTester.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ManaBaseData.Repositories
{
    public class RangeRepository<TEntity> : IRangeRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext DbContext;

        public DbContext Database { get { return DbContext; } }
        public DbSet<TEntity> Entities { get; }
        private ResourceManagerSingleton resource;
        private TimeDurationTrackerSingleton tester;

        public RangeRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
            resource = ResourceManagerSingleton.GetInstance();
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var query = Entities
                .Skip(total)
                .Take(more)
                .AsQueryable();
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity>(feilds);
            var result = await query.ToListAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), total, more));      // SAVE SPEEDT TEST RESULT
            return result;
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            if (entities == null || !entities.Any())
                return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "ورودی نامناسب");
            int Result = 0;
            Assert.NotNull(entities, nameof(entities));
            entities = entities.FixPersianText();
            entities = entities.SetCreationTimes();
            entities = entities.FixDeleteAndActivation();
            await Entities.AddRangeAsync(entities, new CancellationToken()).ConfigureAwait(false);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();
                query = entities.SetOrder<TEntity>(query.GetOrderFeilds<TEntity>());
                var result = query.ToList();
                tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
                return result;
            }
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            int Result = 0;
            Entities.Local.Clear();
            entities.ToList().ForEach(delegate (TEntity entity)
            {
                Assert.NotNull(entity, nameof(entity));
                Entities.Attach(entity).State = EntityState.Modified;
            });
            entities = entities.FixPersianText();
            entities = entities.SetModifiedTimes();
            Entities.UpdateRange(entities);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();
                query = entities.SetOrder<TEntity>(query.GetOrderFeilds<TEntity>());
                var result = query.ToList();
                tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
                return result;
            }
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            var start = DateTime.Now;       // START SPEED TEST
            int Result = 0;
            Assert.NotNull(entities, nameof(entities));
            entities.SetDeletedToProperty(Entities);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();
                query = entities.SetOrder<TEntity>(query.GetOrderFeilds<TEntity>());
                var result = await query.ToListAsync();
                tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
                return result;
            }
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entities));      // SAVE SPEEDT TEST RESULT
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            int Result = 0;
            var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();
            var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();
            var query = Entities
                .FromSqlRaw($"select * from [{schema}].[{table}] where [Id] in ({string.Join(",", ids)})")
                .AsQueryable();
            IEnumerable<TEntity> entities = await query.ToListAsync();
            entities.SetDeletedToProperty(Entities);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
            {
                var query1 = entities.AsQueryable<TEntity>();
                query1 = entities.SetOrder<TEntity>(query.GetOrderFeilds<TEntity>());
                var result = query1.ToList();
                tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
                return result;
            }
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
    }
}
