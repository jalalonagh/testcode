using Common.Models;
using ManaEnums.Api;
using ManaEnums.Extensions;

namespace Services.Models
{
    public class ServiceResult : MethodResponseModel
    {
        public ServiceResult(bool isSuccess, ApiResultStatus statusCode, string message = null) : base(isSuccess, statusCode, message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }
        public ServiceResult(bool isSuccess, ApiResultStatus statusCode, object data, string message = null) : base(isSuccess, statusCode, data, message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            Data = data;
        }

        public object GetData()
        {
            return Data;
        }

        public T GetData<T>()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json ?? "");
        }

        public bool GetIsSuccess()
        {
            return IsSuccess;
        }
        public ApiResultStatus GetStatus()
        {
            return StatusCode;
        }
        public string GetMessage()
        {
            return Message;
        }
    }
}
