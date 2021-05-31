using ManaEnums.Api;
using System;

namespace Common.Exceptions
{
    public class NOT_FOUNDException : AppException
    {
        public NOT_FOUNDException()
            : base(ApiResultStatus.NOT_FOUND)
        {
        }

        public NOT_FOUNDException(string message)
            : base(ApiResultStatus.NOT_FOUND, message)
        {
        }

        public NOT_FOUNDException(object additionalData)
            : base(ApiResultStatus.NOT_FOUND, additionalData)
        {
        }

        public NOT_FOUNDException(string message, object additionalData)
            : base(ApiResultStatus.NOT_FOUND, message, additionalData)
        {
        }

        public NOT_FOUNDException(string message, Exception exception)
            : base(ApiResultStatus.NOT_FOUND, message, exception)
        {
        }

        public NOT_FOUNDException(string message, Exception exception, object additionalData)
            : base(ApiResultStatus.NOT_FOUND, message, exception, additionalData)
        {
        }
    }
}
