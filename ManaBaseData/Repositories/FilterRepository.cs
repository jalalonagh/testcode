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
    public class FilterRepository<TEntity, TSearchEntity> : IFilterRepository<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        protected readonly ApplicationDbContext DbContext;

        public DbContext Database { get { return DbContext; } }
        public DbSet<TEntity> Entities { get; }
        private ResourceManagerSingleton resource;
        private TimeDurationTrackerSingleton tester;

        public FilterRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
            resource = ResourceManagerSingleton.GetInstance();
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public async Task<RepositoryResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var properties = filter.Entity.GetType()
                .GetProperties()
                .Where(x => x.PropertyType.IsValueType
                && (x.PropertyType != typeof(string) && x.GetValue(filter.Entity) != null)
                || (x.PropertyType == typeof(string) && !string.IsNullOrEmpty(x.GetValue(filter.Entity)?.ToString())))
                .ToList();
            var query = Entities
                .Skip(filter.Total)
                .Take(filter.More)
                .AsQueryable();
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            query = query.SetWhere<TEntity, TSearchEntity>(properties, filter.Entity);
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity>(feilds);
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            IEnumerable<TEntity> data = await query
                .ToListAsync();
            var result = await query.ToListAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), filter));      // SAVE SPEEDT TEST RESULT
            return result;
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            Expression<Func<TEntity, bool>> funcs = null;
            var start = DateTime.Now;       // START SPEED TEST
            var properties = search.Entity.GetType()
                .GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .ToList();
            var query = Entities
                .Skip(search.Total)
                .Take(search.More)
                .AsQueryable();
            if (properties != null && properties.Any())
                foreach (var item in properties)
                    if (funcs == null)
                        funcs = ExpressionHelper.GetPredicate<TEntity>(item.Name, ExpressionHelper.SearchType.Contains, search.Text);
                    else
                        funcs = funcs.Or<TEntity>(ExpressionHelper.GetPredicate<TEntity>(item.Name, ExpressionHelper.SearchType.Contains, search.Text));
            query = query.Where(funcs);
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity>(feilds);
            var result = await query
                .ToListAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), search));      // SAVE SPEEDT TEST RESULT
            return result;
        }
    }
}
