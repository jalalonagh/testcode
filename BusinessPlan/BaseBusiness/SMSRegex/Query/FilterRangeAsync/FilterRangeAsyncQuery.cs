using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities.SMSRegex;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<SMSRegexSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<SMSRegexSearch> Model { get; }
    }
}