using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities.SMS;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Query.FilterRangeAsync
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