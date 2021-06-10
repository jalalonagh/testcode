using Entities;
using Entities.Common;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Data
{
    public static class EntityFuncs
    {
        public static Expression<Func<TEntity, bool>> SearchApplyFunc<TEntity, TSearch>(this string property)
            where TEntity : class, IEntity
            where TSearch : class, ISearchEntity
        {
            ParameterExpression argParam = Expression.Parameter(typeof(TSearch), property);
            Expression nameProperty = Expression.Property(argParam, property);
            Expression namespaceProperty = Expression.Property(argParam, property);

            var val1 = Expression.Constant(property);
            var val2 = Expression.Constant(property);

            Expression e1 = Expression.Equal(nameProperty, val1);
            Expression e2 = Expression.Equal(namespaceProperty, val2);

            var andExp = Expression.AndAlso(e1, e2);

            return Expression.Lambda<Func<TEntity, bool>>(andExp, argParam);
        }

        public static Expression<Func<TEntity, bool>> ApplyFunc<TEntity>(this PropertyInfo property, dynamic value)
            where TEntity : class, IEntity
        {
            ParameterExpression argParam = Expression.Parameter(typeof(TEntity), property.Name);
            Expression nameProperty = Expression.Property(argParam, property);
            Expression namespaceProperty = Expression.Property(argParam, property);

            var val1 = Expression.Constant(value);
            var val2 = Expression.Constant(value);

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
