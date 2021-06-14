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
        public static TEntity FixDeleteAndActivation<TEntity>(this TEntity entity, bool isActive = true, bool isDeleted = false)
            where TEntity : class, IEntity
        {
            entity.IsActive = isActive;
            entity.IsDeleted = isDeleted;
            return entity;
        }
        public static IEnumerable<TEntity> FixDeleteAndActivation<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            List<TEntity> persianEntities = new List<TEntity>();
            entities.ToList().ForEach(delegate (TEntity entity)
            {
                entity = FixDeleteAndActivation(entity);
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
        public static IQueryable<TEntity> SetOrder<TEntity, TSearch>(this IQueryable<TEntity> query, IEnumerable<PropertyInfo> fields)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query = query.OrderByDescending(item.Order<TEntity>());
            return query;
        }
        public static IQueryable<TEntity> SetOrder<TEntity, TSearch>(this IEnumerable<TEntity> entities, IEnumerable<PropertyInfo> fields)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            var query = entities.AsQueryable();

            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query = query.OrderByDescending(item.Order<TEntity>());
            return query;
        }
        public static IQueryable<TEntity> SetWhere<TEntity, TSearch>(this IQueryable<TEntity> query, IEnumerable<PropertyInfo> fields, TSearch entity)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query = query.Where(ExpressionHelper.GetPredicate<TEntity>(item.Name, ExpressionHelper.SearchType.Equal, item.GetValue(entity)));
            return query;
        }
        public static IQueryable<TEntity> SetWhere<TEntity, TSearch>(this IEnumerable<TEntity> entities, IEnumerable<PropertyInfo> fields, TSearch entity)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            var query = entities.AsQueryable();
            if (fields != null && fields.Any())
                foreach (var item in fields)
                    query = query.Where(ExpressionHelper.GetPredicate<TEntity>(item.Name, ExpressionHelper.SearchType.Equal, item.GetValue(entity)));
            return query;
        }
        public static IEnumerable<PropertyInfo> GetOrderFeilds<TEntity>(this IQueryable<TEntity> query)
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
                name = s,
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
        public static TEntity SetDeletedToEntity<TEntity>(this TEntity entity, DbSet<TEntity> db)
            where TEntity : class, IEntity
        {
            if (entity != null && db != null)
            {
                var deleteProperty = entity.GetType().GetProperty(nameof(entity.IsDeleted));
                if (deleteProperty != null)
                {
                    deleteProperty.SetValue(entity, true);
                    db.Attach(entity).State = EntityState.Modified;
                    db.Update(entity);
                }
            }

            return entity;
        }
        public static void SetDeletedToProperty<TEntity>(this IEnumerable<TEntity> entities, DbSet<TEntity> db)
            where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                entity.SetDeletedToEntity<TEntity>(db);
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
        public static object? GetPropertyValue(this PropertyInfo info, object data)
        {
            if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var result = info.GetValue(data);
                return info.GenerateNullableValue(result);
            }
            return info.GetValue(data);
        }
        public static object? GenerateNullableValue(this PropertyInfo info, object value)
        {
            switch (info.PropertyType.GetGenericArguments()[0].Name)
            {
                case "Int32":
                    return new int?((int)value);
                case "Int64":
                    return new long?((long)value);
                case "DateTime":
                    return new DateTime?((DateTime)value);
                case "TimeSpan":
                    return new TimeSpan?((TimeSpan)value);
                case "Decimal":
                    return new decimal?((decimal)value);
                case "Byte":
                    return new byte?((byte)value);
                case "Int16":
                    return new short?((short)value);
                case "UInt16":
                    return new ushort?((ushort)value);
                case "UInt32":
                    return new uint?((uint)value);
                case "UInt64":
                    return new ulong?((ulong)value);
                case "Char":
                    return new char?((char)value);
                case "Single":
                    return new float?((float)value);
                case "Double":
                    return new double?((double)value);
                case "Boolean":
                    return new bool?((bool)value);
                default:
                    return null;
            }
        }
    }
}
