
using Common.Utilities;
using Entities;
using Entities.Common;
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

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
        }

        #region Async Method
        public async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();
            var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();

            var query = Entities
                .Where(w => ids.Contains(w.Id))
                .AsNoTracking()
                .AsQueryable();

            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FetchByIdAsync(CancellationToken cancellationToken, int id)
        {
            var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();
            var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();

            var query = Entities
                .FromSqlRaw($"select * from [{schema}].[{table}] where [Id] = {id}")
                .AsNoTracking()
                .AsQueryable();

            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            return await query.Take(1).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, int total = 0, int more = int.MaxValue)
        {
            var query = Entities
                .AsNoTracking()
                .Skip(total)
                .Take(more)
                .AsQueryable();

            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            var feilds = query.GetOrderFeilds<TEntity>();

            query = query.SetOrder<TEntity, TSearchEntity>(feilds);

            return await query.ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            Assert.NotNull(entity, nameof(entity));

            entity = entity.FixPersianText();

            entity = entity.SetCreationTime();

            await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);

            Result = await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (Result > 0)
                return entity;

            return null;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            Assert.NotNull(entities, nameof(entities));

            entities = entities.FixPersianText();

            entities = entities.SetCreationTimes();

            await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);

            Result = await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();

                query = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());

                return await query.ToListAsync();
            }

            return null;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            Assert.NotNull(entity, nameof(entity));

            entity = entity.FixPersianText();

            entity = entity.SetModifiedTime();

            Entities.Update(entity);

            Result = await DbContext.SaveChangesAsync(cancellationToken);

            if (Result > 0)
                return entity;

            return null;
        }

        public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
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

            Result = await DbContext.SaveChangesAsync(cancellationToken);

            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();

                query = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());

                return await query.ToListAsync();
            }

            return null;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            Assert.NotNull(entity, nameof(entity));

            var deleteProperty = entity.GetType().GetProperty("deleted");
            if (deleteProperty != null)
            {
                deleteProperty.SetValue(entity, true);
                Entities.Attach(entity).State = EntityState.Modified;
                Entities.Update(entity);

                Result = await DbContext.SaveChangesAsync();

                return entity;
            }

            if (Result > 0)
                return entity;

            return null;
        }

        public async Task<TEntity> DeleteByIdAsync(int id, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();
            var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();

            var query = Entities
                .FromSqlRaw($"select * from [{schema}].[{table}] where [Id] = {id}")
                .AsNoTracking()
                .AsQueryable();

            var entity = await query.FirstOrDefaultAsync();

            var deleteProperty = entity.GetType().GetProperty("deleted");

            if (deleteProperty != null)
            {
                deleteProperty.SetValue(entity, true);
                Entities.Attach(entity).State = EntityState.Modified;
                Entities.Update(entity);

                Result = await DbContext.SaveChangesAsync();

                return entity;
            }

            if (Result > 0)
                return entity;

            return null;
        }

        public async Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            Assert.NotNull(entities, nameof(entities));

            foreach (var entity in entities)
            {
                var deleteProperty = entity.GetType().GetProperty("deleted");
                if (deleteProperty != null)
                {
                    deleteProperty.SetValue(entity, true);
                    Entities.Attach(entity).State = EntityState.Modified;
                    Entities.Update(entity);
                }
            }

            Result = await DbContext.SaveChangesAsync(cancellationToken);

            if (Result > 0)
            {
                var query = entities.AsQueryable<TEntity>();

                query = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());

                return await query.ToListAsync();
            }

            return null;
        }

        public async Task<IEnumerable<TEntity>> DeleteRangeByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken, bool saveNow = true)
        {
            int Result = 0;

            var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();
            var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();

            var query = Entities
                .FromSqlRaw($"select * from [{schema}].[{table}] where [Id] in ({string.Join(",", ids)})")
                .AsNoTracking()
                .AsQueryable();

            IEnumerable<TEntity> entities = await query.ToListAsync();

            foreach (var entity in entities)
            {
                var deleteProperty = entity.GetType().GetProperty("deleted");
                if (deleteProperty != null)
                {
                    deleteProperty.SetValue(entity, true);
                    Entities.Attach(entity).State = EntityState.Modified;
                    Entities.Update(entity);
                }
            }

            Result = await DbContext.SaveChangesAsync(cancellationToken);

            if (Result > 0)
            {
                var query1 = entities.AsQueryable<TEntity>();

                query1 = entities.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());

                return await query1.ToListAsync();
            }

            return null;
        }
        #endregion

        #region Attach & Detach
        public TEntity Detach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            var entry = DbContext.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Detached;

            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            if (DbContext.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);

            return entity;
        }
        #endregion

        #region JalalQuery
        public async Task<IEnumerable<TEntity>> FilterRangeAsync(TSearchEntity entity, CancellationToken cancel, int total = 0, int more = int.MaxValue)
        {
            var properties = entity.GetType()
                .GetProperties()
                .Where(x => (x.PropertyType != typeof(string) && x.GetValue(entity) != null) || (x.PropertyType == typeof(string) && !string.IsNullOrEmpty(x.GetValue(entity).ToString())))
                .ToList();

            var entityType = Database.Model.FindEntityType(typeof(TEntity));
            var schema = entityType.GetSchema();
            var tableName = entityType.GetTableName();

            var query = Entities
                .AsNoTracking()
                .Skip(total)
                .Take(more)
                .AsQueryable();

            query = query.ClearDeletedOrNotActiveEntity<TEntity>();

            query = query.SetWhere<TEntity, TSearchEntity>(properties, entity);

            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            IEnumerable<TEntity> data = await query
                .ToListAsync();

            query = query.SetOrder<TEntity, TSearchEntity>(query.GetOrderFeilds<TEntity>());

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> SearchRangeAsync(TEntity entity, string text, CancellationToken cancel, int total = 0, int more = int.MaxValue)
        {
            var deletedProp = entity.GetType().GetProperty("deleted");
            if (deletedProp != null)
                deletedProp.SetValue(entity, null);

            var properties = entity.GetType()
                .GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .ToList();

            var entityType = Database.Model.FindEntityType(typeof(TEntity));
            var schema = entityType.GetSchema();
            var tableName = entityType.GetTableName();
            var sql = $"select * from {schema}.{tableName} ";

            if (!properties.Equals(null) && properties.Count() > 0)
            {
                sql += "where (";
                properties.ForEach(delegate (PropertyInfo info)
                {
                    // check and deactivate default numbers like 0 into search and filter action
                    //if (info.PropertyType == typeof(string))
                    sql += $" [{info.Name}] like N'%{text}%' or";
                });

                sql = sql.Substring(0, sql.Length - 2);

                sql = sql + ") and ";

                sql += sql.FixedSqlQueryParameters<TEntity>();

                sql = sql.Substring(0, sql.Length - 3);
                //sql += ";";
            }

            var query = Entities.FromSqlRaw(sql)
                .AsNoTracking()
                .Skip(total)
                .Take(more)
                .AsQueryable();

            foreach (var property in DbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            var feilds = query.GetOrderFeilds<TEntity>();

            query = query.SetOrder<TEntity, TSearchEntity>(feilds);

            return await query
                .ToListAsync();
        }

        public async Task<TEntity> UpdateFieldRangeAsync(CancellationToken cancellation, TEntity entity, params string[] fields)
        {
            if (entity != null && fields.Length > 0)
            {
                var properties = entity.GetType().GetProperties();

                if (properties != null && properties.Length > 0)
                {
                    var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();
                    var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();
                    var id = entity.GetType().GetProperties().Where(w => w.Name == "Id").FirstOrDefault();

                    var query = Entities
                        .FromSqlRaw($"select * from [{schema}].[{table}] where [Id] = {id.GetValue(entity)}")
                        .AsNoTracking()
                        .AsQueryable();

                    var data = await query.FirstOrDefaultAsync();

                    if (data != null)
                    {
                        foreach (var field in fields)
                        {
                            var prop = properties.Where(w => w.Name == field).FirstOrDefault();
                            if (prop != null)
                            {
                                prop.SetValue(data, prop.GetValue(entity));
                            }
                        }
                    }

                    var result = -1;

                    Entities.Update(data);
                    //if (saveNow)
                    result = await DbContext.SaveChangesAsync(cancellation);

                    if (result > 0)
                        return data;

                    return null;
                }
            }
            return null;
        }

        public async Task<TEntity> UpdateFieldRangeAsync(CancellationToken cancellation, int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            bool saveNow = true;
            if (fields != null && Id > 0 && fields.Length > 0)
            {
                var schema = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetSchema();
                var table = Entities.GetContext().Model.FindEntityType(typeof(TEntity)).GetTableName();

                var query = Entities
                    .FromSqlRaw($"select * from [{schema}].[{table}] where [Id] = {Id}")
                    .AsNoTracking()
                    .AsQueryable();

                var data = await query.FirstOrDefaultAsync();

                var properties = data.GetType().GetProperties();

                if (properties != null && properties.Length > 0)
                {
                    if (data != null)
                    {
                        foreach (var field in fields)
                        {
                            var prop = properties.Where(w => w.Name == field.Key).FirstOrDefault();
                            if (prop != null)
                            {
                                prop.SetValue(data, field.Value);
                            }
                        }
                    }

                    var result = -1;

                    Entities.Update(data);
                    //if (saveNow)
                    result = await DbContext.SaveChangesAsync(cancellation);

                    if (result > 0)
                        return data;

                    return null;
                }
            }
            return null;
        }
        #endregion JalalQuery
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
