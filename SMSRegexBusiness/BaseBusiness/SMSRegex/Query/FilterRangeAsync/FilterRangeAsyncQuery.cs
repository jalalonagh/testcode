using BusinessBaseConfig.Configuration.Queries;
using Data.Repositories.Models;
using Entities.SMSRegex;
using Services.Models;
using System.Collections.Generic;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Query.FilterRangeAsync
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