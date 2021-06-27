using BusinessBaseConfig.Configuration.Queries;
using Entities.SMS;
using Services.Models;
using System.Collections.Generic;

namespace SMSBusiness.BaseBusinessLevel.SMS.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<SMSSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<SMSSearch> Model { get; }
    }
}