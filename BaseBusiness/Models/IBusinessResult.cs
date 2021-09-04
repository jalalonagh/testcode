using Services.Models;

namespace BaseBusiness.Models
{
    public interface IBusinessResult
    {
        void FromServiceResult(ServiceResult result);
    }

    public interface IBusinessResult<TData>
        where TData : class
    {
        public TData GetData();
        public bool GetIsSuccess();
        void FromServiceResult(ServiceResult<TData> result);
    }
}
