﻿using System;
using System.Collections;
using System.Linq;
using Common.Exceptions;
using ManaEnums.Api;

namespace Common.Utilities
{
    public static class Assert
    {
        public static void NotNull<T>(T obj, string name, string message = null)
            where T : class
        {
            if (obj is null)
                throw new AppException(ApiResultStatus.BAD_REQUEST,
                    message,
                    new ArgumentNullException($"{name} : {typeof(T)}", message));
 

        }

        public static void NotNull<T>(T? obj, string name, string message = null)
            where T : struct
        {
            if (!obj.HasValue)
                throw new AppException(ApiResultStatus.BAD_REQUEST,
                    message,
         new ArgumentNullException($"{name} : {typeof(T)}", $"## {message} &&"));

        }

        public static void NotEmpty<T>(T obj, string name, string message = null, T defaultValue = null)
            where T : class
        {
            if (obj == defaultValue
                || (obj is string str && string.IsNullOrWhiteSpace(str))
                || (obj is IEnumerable list && !list.Cast<object>().Any()))
            {
                throw new AppException(ApiResultStatus.BAD_REQUEST,
                    message,
                    new ArgumentException("Argument is empty : " + $"## {message} &&", $"{name} : {typeof(T)}"));

            }
        }
    }
}