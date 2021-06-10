using BusinessLayout.Configuration.Queries;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.GetAllAsync
{
    public class GetAllAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public GetAllAsyncQuery(int total, int more)
        {
            Total = total;
            More = more;
        }

        public int Total { get; }
        public int More { get; }
    }
}