using BusinessLayout.Configuration.Queries;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.GetAllAsync
{
    public class GetAllAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
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