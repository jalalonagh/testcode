using Common.Utilities;
using Entities;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public static class EntityFuncs
    {
        public static Expression<Func<TEntity, bool>> ApplyFunc<TEntity, TSearch>(this string property)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            ParameterExpression argParam = Expression.Parameter(typeof(TSearch), property);
            Expression nameProperty = Expression.Property(argParam, "Name");
            Expression namespaceProperty = Expression.Property(argParam, "Namespace");

            var val1 = Expression.Constant("Name");
            var val2 = Expression.Constant("Namespace");

            Expression e1 = Expression.Equal(nameProperty, val1);
            Expression e2 = Expression.Equal(namespaceProperty, val2);

            var andExp = Expression.AndAlso(e1, e2);

            return Expression.Lambda<Func<TEntity, bool>>(andExp, argParam);
        }

        public static Expression<Func<TEntity, bool>> ApplyWhereFunc<TEntity, TSearch>(this string propertyName, dynamic propertyValue)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            var parameter = Expression.Parameter(typeof(TSearch), $"{nameof(TSearch).Substring(0, 2)}");

            var property = Expression.Property(parameter, propertyName);

            var clause = Expression.Equal(property, Expression.Constant(propertyValue));

            return Expression.Lambda<Func<TEntity, bool>>(clause, parameter);
        }

        public static Expression<Func<TEntity, bool>> ApplyWhereLikeFunc<TEntity, TSearch>(this string propertyName, dynamic propertyValue)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            MethodInfo contains = typeof(string).GetMethod("Contains");

            ParameterExpression parameter = Expression.Parameter(typeof(TSearch), $"{nameof(TSearch).Substring(0, 2)}");

            var property = Expression.Property(parameter, propertyName);

            var call = Expression.Call(property, contains, Expression.Constant(propertyValue, typeof(string)));

            return Expression.Lambda<Func<TEntity, bool>>(call, parameter);
        }
    }
}
