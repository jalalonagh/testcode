
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ManaBaseData
{
    public static class ExpressionHelper
    {
        public enum SearchType
        {
            IsIn,
            NotEqual,
            Equal,
            Less,
            LessOrEqual,
            Greater,
            GreaterOrEqual,
            BeginsWith,
            DoesNotBeginWith,
            IsNotIn,
            EndsWith,
            DoesNotEndWith,
            Contains,
            DoesNotContain,
            IsNull,
            IsNotNull
        }

        /// <summary>
        ///  This is main Method of this Class It returns predicate
        ///  
        /// </summary>
        /// <typeparam name="T">Entity Type - Search Where</typeparam>
        /// <param name="modelPropertyName">property to compare (compare what)(can be nested property)</param>
        /// <param name="searchType">comparation Type (compare how)</param>
        /// <param name="data">data to compare (compare to what )</param>
        /// <returns>Able to translate to SQl predicate</returns>
        public static Expression<Func<T, bool>> GetPredicate<T>(string modelPropertyName, SearchType searchType, object data) where T : class
        {
            ParameterExpression parameterExp = Expression.Parameter(typeof(T), "t");
            MemberExpression member = Expression.PropertyOrField(parameterExp, modelPropertyName.Split('.').First());
            foreach (var innerMember in modelPropertyName.Split('.').Skip(1))
                member = Expression.PropertyOrField(member, innerMember);
            if (member.Type.BaseType.ToString() == "System.Enum")
            {
                data = Int32.Parse(data.ToString());
                string name = Enum.GetName(member.Type, data);
                data = Enum.Parse(member.Type, name, false);
            }
            else if (searchType != SearchType.IsIn)
            {
                if (member.Type.GetGenericArguments() != null && member.Type.GetGenericArguments().Length > 0)
                    data = member.Type.ToString().ConvertToNullable(data);
                else
                    data = member.Type.ToString().ConvertToNotNullable(data);
            }
            ConstantExpression valuetoCheck;
            if (searchType == SearchType.IsIn)
                valuetoCheck = Expression.Constant(data, GetListType(member.Type));
            else
                valuetoCheck = Expression.Constant(data, member.Type);
            Expression expression = getExpression<T>(searchType, member, valuetoCheck);
            Expression<Func<T, bool>> predicate = Expression.Lambda<Func<T, bool>>(expression, new ParameterExpression[] { parameterExp });
            return predicate;
        }
        private static Expression getExpression<T>(SearchType searchType, MemberExpression member, ConstantExpression valuetoCheck) where T : class
        {
            Expression expression;
            switch (searchType)
            {
                case SearchType.Equal:
                    expression = Equals<T>(member, valuetoCheck);
                    break;
                case SearchType.NotEqual:
                    expression = NotEquals<T>(member, valuetoCheck);
                    break;
                case SearchType.Less:
                    expression = Less<T>(member, valuetoCheck);
                    break;
                case SearchType.LessOrEqual:
                    expression = LessOrEqual<T>(member, valuetoCheck);
                    break;
                case SearchType.Greater:
                    expression = More<T>(member, valuetoCheck);
                    break;
                case SearchType.GreaterOrEqual:
                    expression = MoreorEqual<T>(member, valuetoCheck);
                    break;
                case SearchType.BeginsWith:
                    expression = BeginsWith<T>(member, valuetoCheck);
                    break;
                case SearchType.DoesNotBeginWith:
                    expression = NotBeginsWith<T>(member, valuetoCheck);
                    break;
                case SearchType.IsIn:
                    expression = IsIn<T>(member, valuetoCheck);
                    break;
                case SearchType.IsNotIn:
                    expression = NotContains<T>(member, valuetoCheck);
                    break;
                case SearchType.EndsWith:
                    expression = EndsWith<T>(member, valuetoCheck);
                    break;
                case SearchType.DoesNotEndWith:
                    expression = NotEndsWith<T>(member, valuetoCheck);
                    break;
                case SearchType.Contains:
                    expression = Contains<T>(member, valuetoCheck);
                    break;
                case SearchType.DoesNotContain:
                    expression = NotContains<T>(member, valuetoCheck);
                    break;
                case SearchType.IsNull:
                    expression = IsNull<T>(member, valuetoCheck);
                    break;
                case SearchType.IsNotNull:
                    expression = IsNotNull<T>(member, valuetoCheck);
                    break;
                default:
                    expression = Expression<Func<T, bool>>.Equal(member, valuetoCheck);
                    break;
            }
            return expression;
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, object>> Order<T>(this PropertyInfo property, dynamic value)
        {
            var param = Expression.Parameter(typeof(T), "o");
            Expression conversion = Expression.Convert(Expression.Property(param, property.Name), typeof(object));
            return Expression.Lambda<Func<T, object>>(conversion, param);
        }
        public static Expression<Func<T, bool>> False<T>()
        {
            return f => false;
        }
        public static Expression<Func<T, bool>> True<T>()
        {
            return f => true;
        }
        public static IList CreateList(Type type)
        {
            Type genericListType = typeof(List<>).MakeGenericType(type);
            return ((IList)Activator.CreateInstance(genericListType));
        }
        public static Type GetListType(Type type)
        {
            return CreateList(type).GetType();
        }
        private static Expression BeginsWith<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            return Expression<Func<T, bool>>.Call(member, method, valuetoCheck);
        }
        private static Expression Contains<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return Expression<Func<T, bool>>.Call(member, method, valuetoCheck);
        }
        private static Expression IsIn<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = GetListType(member.Type).GetMethod("Contains", new[] { member.Type });
            return Expression<Func<T, bool>>.Call(valuetoCheck, method, member);
        }
        private static Expression EndsWith<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            return Expression<Func<T, bool>>.Call(member, method, valuetoCheck);
        }
        private static Expression Equals<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.Equal(member, valuetoCheck);
        }
        private static Expression IsNotNull<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.NotEqual(member, Expression.Constant(null, member.Type));
        }
        private static Expression IsNull<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.Equal(member, Expression.Constant(null, member.Type));
        }
        private static Expression Less<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.LessThan(member, valuetoCheck);
        }
        private static Expression LessOrEqual<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.LessThanOrEqual(member, valuetoCheck);
        }
        private static Expression More<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.GreaterThan(member, valuetoCheck);
        }
        private static Expression MoreorEqual<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.GreaterThanOrEqual(member, valuetoCheck);
        }
        private static Expression NotBeginsWith<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            return Expression.Not(Expression<Func<T, bool>>.Call(member, method, valuetoCheck));
        }
        private static Expression NotContains<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return Expression.Not(Expression<Func<T, bool>>.Call(member, method, valuetoCheck));
        }
        private static Expression NotEndsWith<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            MethodInfo method = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            return Expression.Not(Expression<Func<T, bool>>.Call(member, method, valuetoCheck));
        }
        private static Expression NotEquals<T>(MemberExpression member, ConstantExpression valuetoCheck)
        {
            return Expression<Func<T, bool>>.NotEqual(member, valuetoCheck);
        }
        private static UInt64? ToNullableUInt64(this string s)
        {
            UInt64 i;
            if (UInt64.TryParse(s, out i)) return i;
            return null;
        }
        private static UInt32? ToNullableUInt32(this string s)
        {
            UInt32 i;
            if (UInt32.TryParse(s, out i)) return i;
            return null;
        }
        private static UInt16? ToNullableUInt16(this string s)
        {
            UInt16 i;
            if (UInt16.TryParse(s, out i)) return i;
            return null;
        }
        private static Int64? ToNullableInt64(this string s)
        {
            Int64 i;
            if (Int64.TryParse(s, out i)) return i;
            return null;
        }
        private static Int32? ToNullableInt32(this string s)
        {
            Int32 i;
            if (Int32.TryParse(s, out i)) return i;
            return null;
        }
        private static Int16? ToNullableInt16(this string s)
        {
            Int16 i;
            if (Int16.TryParse(s, out i)) return i;
            return null;
        }
        private static float? ToNullableFloat(this string s)
        {
            float i;
            if (float.TryParse(s, out i)) return i;
            return null;
        }
        private static double? ToNullableDouble(this string s)
        {
            double i;
            if (double.TryParse(s, out i)) return i;
            return null;
        }
        private static Decimal? ToNullableDecimal(this string s)
        {
            decimal i;
            if (Decimal.TryParse(s, out i)) return i;
            return null;
        }
        private static Boolean? ToNullableBoolean(this string s)
        {
            bool i;
            if (Boolean.TryParse(s, out i)) return i;
            return null;
        }
        private static DateTime? ToNullableDateTime(this string s)
        {
            DateTime i;
            if (DateTime.TryParse(s, out i)) return i;
            return null;
        }
        private static object ConvertToNullable(this string type, object data)
        {
            switch (type)
            {
                case "System.Nullable`1[System.Decimal]":
                    return data.ToString().ToNullableDecimal();
                case "System.Nullable`1[System.Double]":
                    return data.ToString().ToNullableDouble();
                case "System.Nullable`1[System.Float]":
                    return data.ToString().ToNullableFloat();
                case "System.Nullable`1[System.DateTime]":
                    return data.ToString().ToNullableDateTime();
                case "System.Nullable`1[System.Int16]":
                    return data.ToString().ToNullableInt16();
                case "System.Nullable`1[System.Int32]":
                    return data.ToString().ToNullableInt32();
                case "System.Nullable`1[System.Int64]":
                    return data.ToString().ToNullableInt64();
                case "System.Nullable`1[System.UInt16]":
                    return data.ToString().ToNullableUInt16();
                case "System.Nullable`1[System.UInt32]":
                    return data.ToString().ToNullableUInt32();
                case "System.Nullable`1[System.UInt64]":
                    return data.ToString().ToNullableUInt64();
                case "System.Nullable`1[System.Boolean]":
                    return data.ToString().ToNullableBoolean();
                default:
                    return null;
            }
        }
        private static object ConvertToNotNullable(this string type, object data)
        {
            switch (type)
            {
                case "System.Decimal":
                    return decimal.Parse(data.ToString());
                case "System.Double":
                    return double.Parse(data.ToString());
                case "System.Float":
                    return float.Parse(data.ToString());
                case "System.DateTime":
                    return DateTime.Parse(data.ToString());
                case "System.Int16":
                    return Int16.Parse(data.ToString());
                case "System.Int32":
                    return Int32.Parse(data.ToString());
                case "System.Int64":
                    return Int64.Parse(data.ToString());
                case "System.UInt16":
                    return UInt16.Parse(data.ToString());
                case "System.UInt32":
                    return UInt32.Parse(data.ToString());
                case "System.UInt64":
                    return UInt64.Parse(data.ToString());
                case "System.Byte":
                    return Byte.Parse(data.ToString());
                case "System.Boolean":
                    return Boolean.Parse(data.ToString());
                default:
                    return null;
            }
        }
    }
}
