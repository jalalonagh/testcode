using ManaEnums.Api;
using System;

namespace Common.Exceptions
{
    public class LogicException : AppException
    {
        public LogicException() 
            : base(ApiResultStatus.LOGIC_ERROR)
        {
        }

        public LogicException(string message) 
            : base(ApiResultStatus.LOGIC_ERROR, message)
        {
        }

        public LogicException(object additionalData) 
            : base(ApiResultStatus.LOGIC_ERROR, additionalData)
        {
        }

        public LogicException(string message, object additionalData) 
            : base(ApiResultStatus.LOGIC_ERROR, message, additionalData)
        {
        }

        public LogicException(string message, Exception exception)
            : base(ApiResultStatus.LOGIC_ERROR, message, exception)
        {
        }

        public LogicException(string message, Exception exception, object additionalData)
            : base(ApiResultStatus.LOGIC_ERROR, message, exception, additionalData)
        {
        }
    }
}
