﻿
using Common.Utilities;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaResourceManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity, TSearchEntity> : IRepository<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        protected readonly ApplicationDbContext DbContext;

        public DbContext Database { get { return DbContext; } }
        public DbSet<TEntity> Entities { get; }
        public IQueryable<TEntity> Table => Entities;
        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        private ResourceManagerSingleton resource;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
            resource = ResourceManagerSingleton.Instance;
        }

        public async Task<RepositoryResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            var query = Entities
                .Where(w => ids.Contains(w.Id))
                .AsQueryable();
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity, TSearchEntity>(feilds);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> FetchByIdAsync(int id)
        {
            if (id == 0)
                return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("emptyinputdata").GetMessage());
            var query = Entities
                .Where(w => w.Id == id)
                .AsQueryable();
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity, TSearchEntity>(feilds);
            return await query.Take(1).ToListAsync();
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var query = Entities
                .Skip(total)
                .Take(more)
                .AsQueryable();
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity, TSearchEntity>(feilds);
            return await query.ToListAsync();
        }
        public async Task<RepositoryResult<TEntity>> AddAsync(TEntity entity)
        {
            if (entity == null)
                return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "ورودی نامناسب");
            int Result = 0;
            Assert.NotNull(entity, nameof(entity));
            entity = entity.FixPersianText();
            entity = entity.SetCreationTime();
            await Entities.AddAsync(entity, new CancellationToken()).ConfigureAwait(false);
            Result = await DbContext.SaveChangesAsync().ConfigureAwait(false);
            if (Result > 0)
                return entity;

            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if(entities == null || !entities.Any())
                return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "ورودی نامناسب");
            int Result = 0;
            Assert.NotNull(entities, nameof(entities));
            entities = entities.FixPersianText();
            entities = entities.SetCreationTimes();
            await Entities.AddRangeAsync(entities, new CancellationToken()).ConfigureAwait(false);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();
                query = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());
                return await query.ToListAsync();
            }
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<TEntity>> UpdateAsync(TEntity entity)
        {
            if(entity == null)
                return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "ورودی نامناسب");
            int Result = 0;
            Assert.NotNull(entity, nameof(entity));
            entity = entity.FixPersianText();
            entity = entity.SetModifiedTime();
            Entities.Update(entity);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
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
                query = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());
                return await query.ToListAsync();
            }
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<TEntity>> DeleteAsync(TEntity entity)
        {
            int Result = 0;
            Assert.NotNull(entity, nameof(entity));
            entity.SetDeletedToEntity<TEntity>(Entities);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<TEntity>> DeleteByIdAsync(int id)
        {
            var query = Entities
                .Where(w => w.Id == id)
                .AsQueryable();
            var entity = await query.FirstOrDefaultAsync();
            var result = await DeleteAsync(entity);
            entity = result.Data;
            if (entity != null)
                return entity;
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            int Result = 0;
            Assert.NotNull(entities, nameof(entities));
            entities.SetDeletedToProperty(Entities);
            Result = await DbContext.SaveChangesAsync();
            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();
                query = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());
                return await query.ToListAsync();
            }
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
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
                query1 = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());
                return await query1.ToListAsync();
            }
            return new RepositoryResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
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
        public async Task<RepositoryResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            var properties = filter.Entity.GetType()
                .GetProperties()
                .Where(x => (x.PropertyType != typeof(string) && x.GetValue(filter.Entity) != null) || (x.PropertyType == typeof(string) && !string.IsNullOrEmpty(x.GetValue(filter.Entity).ToString())))
                .ToList();
            var query = Entities
                .Skip(filter.Total)
                .Take(filter.More)
                .AsQueryable();
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            query = query.SetWhere<TEntity, TSearchEntity>(properties, filter.Entity);
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity, TSearchEntity>(feilds);
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            IEnumerable<TEntity> data = await query
                .ToListAsync();
            return await query.ToListAsync();
        }
        public async Task<RepositoryResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
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
                    query = query.Where(EntityFuncs.ApplyWhereLikeFunc<TEntity, TSearchEntity>(item.Name, search.Text));
            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            query = query.ClearDeletedOrNotActiveEntity<TEntity>();
            var feilds = query.GetOrderFeilds<TEntity>();
            query = query.SetOrder<TEntity, TSearchEntity>(feilds);
            return await query
                .ToListAsync();
        }
        public async Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
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
                    if (result > 0)
                        return data;
                    return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
                }
            }
            return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, "داده ورودی نامناسب");
        }
        public async Task<RepositoryResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
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
                if (result > 0)
                    return data;
                return new RepositoryResult<TEntity>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "خطایی رخ داده است");
            }
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
