using ManaEnums.Api;
using ManaEnums.Extensions;

namespace Services.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatus StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ServiceResult(bool isSuccess, ApiResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }
        public ServiceResult(bool isSuccess, ApiResultStatus statusCode, object data, string message = null)
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
