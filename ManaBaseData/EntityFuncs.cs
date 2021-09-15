﻿using ManaBaseEntity.Common;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ManaBaseData
{
    public static class EntityFuncs
    {
        public static Expression<Func<TEntity, object>> Order<TEntity>(this PropertyInfo property)
            where TEntity : class, IEntity
        {
            var param = Expression.Parameter(typeof(TEntity), "x");
            Expression conversion = Expression.Convert(Expression.Property(param, property.Name), typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(conversion, param);
        }
    }
}