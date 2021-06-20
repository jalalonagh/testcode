using BusinessBaseConfig.Configuration.Queries;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Query.GetAllAsync
{
    public class SMSGetAllAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public SMSGetAllAsyncQuery(int total, int more)
        {
            Total = total;
            More = more;
        }

        public int Total { get; }
        public int More { get; }
    }
}