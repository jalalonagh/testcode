using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common.ExtentionLinq
{
   public static class FilterClass
    {
        public static List<Func<TEntity, TCriteria, bool>> GetCriteriaFunctions<TEntity, TCriteria>()
        {
            var criteriaFunctions = new List<Func<TEntity, TCriteria, bool>>();
            var criteriaProperties = typeof(TCriteria)
                .GetProperties()
                .Where(p => (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                || p.PropertyType == typeof(string)
                );
            foreach (var property in criteriaProperties)
            {
                var entityParameterExpression = Expression.Parameter(typeof(TEntity));
                var criteriaParameterExpression = Expression.Parameter(typeof(TCriteria));
                var criteriaPropertyExpression = Expression.Property(criteriaParameterExpression, property);
                var GetGenericArgumentsar = property.PropertyType.GetGenericArguments().Any() ?
                     property.PropertyType.GetGenericArguments()[0] :
                     property.PropertyType;
                Type t = null;
                var type= GetGenericArgumentsar.FullName;
                switch (type)
                {
                    case "System.Int32":
                        t = typeof(int?);
                        break;
                    default:
                        t = typeof(string);
                        break;
                }
                var testingForEqualityExpression = Expression.Equal(
                    Expression.Convert(criteriaPropertyExpression, t),
                    Expression.Property(entityParameterExpression, property.Name));
                var body = Expression.Condition(
                    Expression.Equal(criteriaPropertyExpression, Expression.Constant(null)),
                    Expression.Constant(true),
                    testingForEqualityExpression);
                var criteriaFunction = Expression.Lambda<Func<TEntity, TCriteria, bool>>(body, entityParameterExpression, criteriaParameterExpression).Compile();
                criteriaFunctions.Add(criteriaFunction);
            }
            return criteriaFunctions;
        }
    }
}
