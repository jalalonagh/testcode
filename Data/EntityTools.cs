using Common.Utilities;
using Entities;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public static class EntityTools
    {
        static System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

        public static TEntity FixPersianText<TEntity>(this TEntity entity)
            where TEntity : class, IEntity
        {
            var properties = entity.GetType()
                .GetProperties()
                .Where(x => x.GetValue(entity) != null && x.PropertyType == typeof(string))
                .ToList();

            properties.ForEach(delegate (PropertyInfo info)
            {
                info.SetValue(entity, info.GetValue(entity).ToString().FixPersianChars().En2Fa());
            });

            return entity;
        }

        public static IEnumerable<TEntity> FixPersianText<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            List<TEntity> persianEntities = new List<TEntity>();
            entities.ToList().ForEach(delegate (TEntity entity)
            {
                entity = FixPersianText(entity);
                persianEntities.Add(entity);
            });
            return persianEntities;
        }

        public static IQueryable<TEntity> ClearDeletedOrNotActiveEntity<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class, IEntity
        {
            query = query.Where(w => w.IsActive != false && w.IsDeleted != true);

            return query;
        }

        public static TEntity SetCreationTime<TEntity>(this TEntity entity)
            where TEntity : class, IEntity
        {
            entity = SetCreatedToProperty<TEntity>(entity);

            return entity;
        }

        public static IEnumerable<TEntity> SetCreationTimes<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            IEnumerable<TEntity> newEntities = new List<TEntity>();

            foreach (var entity in entities)
            {
                newEntities = newEntities.Append(SetCreationTime<TEntity>(entity));
            }

            return newEntities;
        }

        public static TEntity SetModifiedTime<TEntity>(this TEntity entity)
            where TEntity : class, IEntity
        {
            entity = SetModifiedTimeToProperty(entity);

            return entity;
        }

        public static IEnumerable<TEntity> SetModifiedTimes<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            IEnumerable<TEntity> newEntities = new List<TEntity>();

            foreach (var entity in entities)
            {
                var e = SetModifiedTimeToProperty(entity);

                newEntities = newEntities.Append(e);
            }

            return newEntities;
        }

        public static IQueryable<TEntity> SetOrder<TEntity, TSearch>(this IQueryable<TEntity> query, IEnumerable<string> fields)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query.OrderByDescending(EntityFuncs.ApplyFunc<TEntity, TSearch>(item));

            return query;
        }

        public static IQueryable<TEntity> SetOrder<TEntity, TSearch>(this IEnumerable<TEntity> entities, IEnumerable<string> fields)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            var query = entities.AsQueryable();

            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query.OrderByDescending(EntityFuncs.ApplyFunc<TEntity, TSearch>(item));

            return query;
        }

        public static IQueryable<TEntity> SetWhere<TEntity, TSearch>(this IQueryable<TEntity> query, IEnumerable<PropertyInfo> fields, TSearch entity)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query.Where(EntityFuncs.ApplyWhereFunc<TEntity, TSearch>(item.Name, item.GetValue(entity)));

            return query;
        }

        public static IQueryable<TEntity> SetWhere<TEntity, TSearch>(this IEnumerable<TEntity> entities, IEnumerable<PropertyInfo> fields, TSearch entity)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            var query = entities.AsQueryable();

            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query.Where(EntityFuncs.ApplyWhereFunc<TEntity, TSearch>(item.Name, item.GetValue(entity)));

            return query;
        }

        public static IEnumerable<string> GetOrderFeilds<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class, IEntity
        {
            var properties = typeof(TEntity).GetProperties();

            var ordered = properties.Where(w => w.CustomAttributes.Any()
            && w.CustomAttributes
            .Where(ww => ww.AttributeType.FullName == "System.ComponentModel.DataAnnotations.Schema.ColumnAttribute")
            .Any())
                .ToList();

            var custom = ordered.Select(s => new
            {
                name = s.Name,
                index = (int)s.CustomAttributes
                .Where(w => w.AttributeType.FullName == "System.ComponentModel.DataAnnotations.Schema.ColumnAttribute")
                .FirstOrDefault().NamedArguments
                .FirstOrDefault().TypedValue.Value
            });

            return custom.OrderBy(o => o.index).Select(s => s.name);
        }

        public static TEntity SetModifiedTimeToProperty<TEntity>(this TEntity entity)
            where TEntity : class, IEntity
        {
            var nowDT = DateTime.Now;
            var propertyCreate = entity.GetType().GetProperty("LastUpdateTime");
            if (propertyCreate != null)
            {
                propertyCreate.SetValue(entity, nowDT);
            }

            var propertyPersianCreate = entity.GetType().GetProperty("LastUpdatePersianTime");
            if (propertyPersianCreate != null)
            {
                var dt = $"{pc.GetYear(nowDT)}/{pc.GetMonth(nowDT)}/{pc.GetDayOfMonth(nowDT)} {nowDT.Hour}:{nowDT.Minute}:{nowDT.Second}";
                propertyPersianCreate.SetValue(entity, dt);
            }

            return entity;
        }

        public static void SetDeletedToProperty<TEntity>(this IEnumerable<TEntity> entities, DbSet<TEntity> db)
            where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                var deleteProperty = entity.GetType().GetProperty("IsDeleted");
                if (deleteProperty != null)
                {
                    deleteProperty.SetValue(entity, true);
                    db.Attach(entity).State = EntityState.Modified;
                    db.Update(entity);
                }
            }
        }

        public static TEntity SetCreatedToProperty<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            var nowDT = DateTime.Now;
            var propertyCreate = entity.GetType().GetProperty("CreateTime");
            if (propertyCreate != null)
            {
                propertyCreate.SetValue(entity, nowDT);
            }

            var propertyPersianCreate = entity.GetType().GetProperty("CreatePersianTime");
            if (propertyPersianCreate != null)
            {
                var dt = $"{pc.GetYear(nowDT)}/{pc.GetMonth(nowDT)}/{pc.GetDayOfMonth(nowDT)} {nowDT.Hour}:{nowDT.Minute}:{nowDT.Second}";
                propertyPersianCreate.SetValue(entity, dt);
            }

            return entity;
        }

        public static TEntity SyncFeildsData<TEntity>(this TEntity entity, IEnumerable<KeyValuePair<string, dynamic>> keyValues)
        {
            if (keyValues != null && keyValues.Any() && entity != null)
            {
                var properties = entity.GetType().GetProperties();
                if (properties != null && properties.Length > 0)
                    if (entity != null)
                        foreach (var field in keyValues)
                        {
                            var prop = properties.Where(w => w.Name == field.Key).FirstOrDefault();
                            if (prop != null)
                                prop.SetValue(entity, field.Value);
                        }
                return entity;
            }
            return default(TEntity);
        }

        public static TEntity SetFieldsValue<TEntity>(this TEntity entity, string[] fields, IEnumerable<PropertyInfo> properties)
            where TEntity : class, IEntity
        {
            if (entity != null)
            {
                foreach (var field in fields)
                {
                    var prop = properties.Where(w => w.Name == field).FirstOrDefault();
                    if (prop != null)
                    {
                        prop.SetValue(entity, prop.GetValue(entity));
                    }
                }
            }

            return entity;
        }
    }
}
