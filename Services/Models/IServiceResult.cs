namespace Services.Models
{
    public interface IServiceResult
    {
    }

    public interface IServiceResult<TData>
        where TData : class
    {
        public TData GetData();
        public bool GetIsSuccess();
    }
}
