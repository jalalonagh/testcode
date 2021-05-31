using Common.Utilities;
using Entities;
using Entities.Common;
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

        public static async Task<TEntity> ItemSync<TEntity>(this TEntity Target, TEntity Origin, CancellationToken cancel)
            where TEntity : class, IEntity
        {
            try
            {
                var Properties = typeof(TEntity).GetProperties()
                    .Where(x => x.GetValue(Target) != null)
                    .ToList();

                Properties.ForEach(delegate (PropertyInfo info)
                {
                    if (info.PropertyType == typeof(Int64) || info.PropertyType == typeof(Int64?))
                    {
                        if ((long)info.GetValue(Target) > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(bool) || info.PropertyType == typeof(bool?))
                    {
                        if (info.GetValue(Target) != null && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(Int32) || info.PropertyType == typeof(Int32?))
                    {
                        if ((int)info.GetValue(Target) > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(float) || info.PropertyType == typeof(float?))
                    {
                        if ((float)info.GetValue(Target) > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(string))
                    {
                        var value = info.GetValue(Target);
                        if (!string.IsNullOrEmpty(Convert.ToString(value)) && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(DateTime) || info.PropertyType == typeof(DateTime?))
                    {
                        if (((DateTime)info.GetValue(Target)).Year > DateTime.MinValue.Year && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(TimeSpan) || info.PropertyType == typeof(TimeSpan?))
                    {
                        if (((TimeSpan)info.GetValue(Target)).TotalSeconds > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(double) || info.PropertyType == typeof(double?))
                    {
                        if (((double)info.GetValue(Target)) > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(decimal) || info.PropertyType == typeof(decimal?))
                    {
                        if (((decimal)info.GetValue(Target)) > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                    else if (info.PropertyType == typeof(byte) || info.PropertyType == typeof(byte?))
                    {
                        if (((byte)info.GetValue(Target)) > 0 && info.GetValue(Target) != info.GetValue(Origin))
                            info.SetValue(Origin, info.GetValue(Target));
                    }
                });

                return Origin;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

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

        public static string FixedSqlQueryParameters<TEntity>(this string query, bool or = false)
            where TEntity : class, IEntity
        {
            if (or)
            {
                return $"{query} ([deleted] is null or [deleted] = 0) or ([isActive] is null or [isActive] = 1) or";
            }

            return $"{query} ([deleted] is null or [deleted] = 0) and ([isActive] is null or [isActive] = 1) and";
        }

        public static TEntity SetCreationTime<TEntity>(this TEntity entity)
            where TEntity : class, IEntity
        {
            var nowDT = DateTime.Now;
            var propertyCreate = entity.GetType().GetProperty("creationDateTime");
            if (propertyCreate != null)
            {
                propertyCreate.SetValue(entity, nowDT);
            }

            var propertyPersianCreate = entity.GetType().GetProperty("creationPersianDateTime");
            if (propertyPersianCreate != null)
            {
                var dt = $"{pc.GetYear(nowDT)}/{pc.GetMonth(nowDT)}/{pc.GetDayOfMonth(nowDT)} {nowDT.Hour}:{nowDT.Minute}:{nowDT.Second}";
                propertyPersianCreate.SetValue(entity, dt);
            }

            return entity;
        }

        public static IEnumerable<TEntity> SetCreationTimes<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            IEnumerable<TEntity> newEntities = new List<TEntity>();

            foreach (var entity in entities)
            {
                var nowDT = DateTime.Now;
                var propertyCreate = entity.GetType().GetProperty("creationDateTime");
                if (propertyCreate != null)
                {
                    propertyCreate.SetValue(entity, nowDT);
                }

                var propertyPersianCreate = entity.GetType().GetProperty("creationPersianDateTime");
                if (propertyPersianCreate != null)
                {
                    var dt = $"{pc.GetYear(nowDT)}/{pc.GetMonth(nowDT)}/{pc.GetDayOfMonth(nowDT)} {nowDT.Hour}:{nowDT.Minute}:{nowDT.Second}";
                    propertyPersianCreate.SetValue(entity, dt);
                }

                newEntities = newEntities.Append(entity);
            }

            return newEntities;
        }

        public static TEntity SetModifiedTime<TEntity>(this TEntity entity)
            where TEntity : class, IEntity
        {
            var nowDT = DateTime.Now;
            var propertyCreate = entity.GetType().GetProperty("modifiedDateTime");
            if (propertyCreate != null)
            {
                propertyCreate.SetValue(entity, nowDT);
            }

            var propertyPersianCreate = entity.GetType().GetProperty("modifiedPersianDateTime");
            if (propertyPersianCreate != null)
            {
                var dt = $"{pc.GetYear(nowDT)}/{pc.GetMonth(nowDT)}/{pc.GetDayOfMonth(nowDT)} {nowDT.Hour}:{nowDT.Minute}:{nowDT.Second}";
                propertyPersianCreate.SetValue(entity, dt);
            }

            return entity;
        }

        public static IEnumerable<TEntity> SetModifiedTimes<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            IEnumerable<TEntity> newEntities = new List<TEntity>();

            foreach (var entity in entities)
            {
                var nowDT = DateTime.Now;
                var propertyCreate = entity.GetType().GetProperty("modifiedDateTime");
                if (propertyCreate != null)
                {
                    propertyCreate.SetValue(entity, nowDT);
                }

                var propertyPersianCreate = entity.GetType().GetProperty("modifiedPersianDateTime");
                if (propertyPersianCreate != null)
                {
                    var dt = $"{pc.GetYear(nowDT)}/{pc.GetMonth(nowDT)}/{pc.GetDayOfMonth(nowDT)} {nowDT.Hour}:{nowDT.Minute}:{nowDT.Second}";
                    propertyPersianCreate.SetValue(entity, dt);
                }

                newEntities = newEntities.Append(entity);
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

            var ordered = properties.Where(w => w.CustomAttributes.Any() && w.CustomAttributes.Where(ww => ww.AttributeType.FullName == "System.ComponentModel.DataAnnotations.Schema.ColumnAttribute").Any()).ToList();

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
    }
}
