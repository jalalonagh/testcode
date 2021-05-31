using ManaEnums.Api;
using System;

namespace Common.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException()
            : base(ApiResultStatus.BAD_REQUEST)
        {
        }

        public BadRequestException(string message)
            : base(ApiResultStatus.BAD_REQUEST, message)
        {
        }

        public BadRequestException(object additionalData)
            : base(ApiResultStatus.BAD_REQUEST, additionalData)
        {
        }

        public BadRequestException(string message, object additionalData)
            : base(ApiResultStatus.BAD_REQUEST, message, additionalData)
        {
        }

        public BadRequestException(string message, Exception exception)
            : base(ApiResultStatus.BAD_REQUEST, message, exception)
        {
        }

        public BadRequestException(string message, Exception exception, object additionalData)
            : base(ApiResultStatus.BAD_REQUEST, message, exception, additionalData)
        {
        }
    }
}
