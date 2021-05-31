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

            // searching for nullable properties of criteria
            var criteriaProperties = typeof(TCriteria)
                .GetProperties()
                .Where(p => (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                || p.PropertyType == typeof(string)
                )
                //.Where(p=>p.PropertyType==typeof(string))
                ;

            foreach (var property in criteriaProperties)
            {
                // this is entity parameter
                var entityParameterExpression = Expression.Parameter(typeof(TEntity));
                // this is criteria parameter
                var criteriaParameterExpression = Expression.Parameter(typeof(TCriteria));
                // this is criteria property access: "criteria.SomeProperty"
                var criteriaPropertyExpression = Expression.Property(criteriaParameterExpression, property);
                // this is testing for equality between criteria property and entity property;
                // note, that criteria property should be converted first;
                // also, this code makes assumption, that entity and criteria properties have the same names



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




                // criteria.SomeProperty == null ? true : ((EntityPropertyType)criteria.SomeProperty == entity.SomeProperty)
                var body = Expression.Condition(
                    Expression.Equal(criteriaPropertyExpression, Expression.Constant(null)),
                    Expression.Constant(true),
                    testingForEqualityExpression);

                // let's compile lambda to method
                var criteriaFunction = Expression.Lambda<Func<TEntity, TCriteria, bool>>(body, entityParameterExpression, criteriaParameterExpression).Compile();

                criteriaFunctions.Add(criteriaFunction);
            }

            return criteriaFunctions;
        }
    }
}
