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
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext DbContext;

        public DbContext Database { get { return DbContext; } }
        public DbSet<TEntity> Entities { get; }
        private ResourceManagerSingleton resource;
        private TimeDurationTrackerSingleton tester;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
            resource = ResourceManagerSingleton.GetInstance();
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public async Task<RepositoryResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var query = Entities
                .Where(w => ids.Contains(w.Id))
                .AsQueryable();
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity>(feilds);
            var result = await query.FirstOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            return result;
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> FetchByIdAsync(int id)
        {
            var start = DateTime.Now;       // START SPEED TEST
            if (id == 0)
                return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("emptyinputdata").GetMessage());
            var query = Entities
                .Where(w => w.Id == id)
                .AsQueryable();
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity>(feilds);
            var result = await query.Take(1).ToListAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), id));      // SAVE SPEEDT TEST RESULT
            return result;
        }
        public async Task<RepositoryResult<TEntity>> AddAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            if (entity == null)
                return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "ورودی نامناسب");
            int Result = 0;
            Assert.NotNull(entity, nameof(entity));
            entity = entity.FixPersianText();
            entity = entity.SetCreationTime();
            entity = entity.FixDeleteAndActivation();
            await Entities.AddAsync(entity, new CancellationToken()).ConfigureAwait(false);
            Result = await DbContext.SaveChangesAsync().ConfigureAwait(false);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            if (Result > 0)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<TEntity>> UpdateAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            if (entity == null)
                return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "ورودی نامناسب");
            int Result = 0;
            Assert.NotNull(entity, nameof(entity));
            entity = entity.FixPersianText();
            entity = entity.SetModifiedTime();
            Entities.Update(entity);
            Result = await DbContext.SaveChangesAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            if (Result > 0)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<TEntity>> DeleteAsync(TEntity entity)
        {
            var start = DateTime.Now;       // START SPEED TEST
            int Result = 0;
            Assert.NotNull(entity, nameof(entity));
            entity.SetDeletedToEntity<TEntity>(Entities);
            Result = await DbContext.SaveChangesAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity));      // SAVE SPEEDT TEST RESULT
            if (Result > 0)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<TEntity>> DeleteByIdAsync(int id)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var query = Entities
                .Where(w => w.Id == id)
                .AsQueryable();
            var entity = await query.FirstOrDefaultAsync();
            var result = await DeleteAsync(entity);
            entity = result.Data;
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), id));      // SAVE SPEEDT TEST RESULT
            if (entity != null)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public RepositoryResult<TEntity> Detach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            var entry = DbContext.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Detached;

            return entity;
        }
        public RepositoryResult<TEntity> Attach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            if (DbContext.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);

            return entity;
        }
        public async Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
            var start = DateTime.Now;       // START SPEED TEST
            if (entity != null && fields.Length > 0)
            {
                var properties = entity.GetType().GetProperties();
                if (properties != null && properties.Length > 0)
                {
                    var id = entity.GetType().GetProperties().Where(w => w.Name == "Id").FirstOrDefault();
                    var query = Entities
                        .Where(w => w.Id == entity.Id)
                        .AsQueryable();
                    var data = await query.FirstOrDefaultAsync();
                    data = data.SetFieldsValue<TEntity>(fields, properties);
                    var result = -1;
                    Entities.Update(data);
                    result = await DbContext.SaveChangesAsync();
                    tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity, fields));      // SAVE SPEEDT TEST RESULT
                    if (result > 0)
                        return data;
                    return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
                }
            }
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), entity, fields));      // SAVE SPEEDT TEST RESULT
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "داده ورودی نامناسب");
        }
        public async Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            var start = DateTime.Now;       // START SPEED TEST
            if (fields != null && Id > 0 && fields.Length > 0)
            {
                var query = Entities
                    .Where(w => w.Id == Id)
                    .AsQueryable();
                var data = await query.FirstOrDefaultAsync();
                data = data.SyncFeildsData(fields);
                var result = -1;
                Entities.Update(data);
                result = await DbContext.SaveChangesAsync();
                tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Id, fields));      // SAVE SPEEDT TEST RESULT
                if (result > 0)
                    return data;
                return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
            }
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), Id, fields));      // SAVE SPEEDT TEST RESULT
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "داده ورودی نامناسب");
        }
    }
    public static class HackyDbSetGetContextTrick
    {
        public static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
            where TEntity : class
        {
            return (DbContext)dbSet
                .GetType().GetTypeInfo()
                .GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
        }
    }
}
