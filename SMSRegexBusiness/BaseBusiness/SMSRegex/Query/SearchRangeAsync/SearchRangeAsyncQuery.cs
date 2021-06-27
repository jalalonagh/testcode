using BusinessBaseConfig.Configuration.Queries;
using Services.Models;
using System.Collections.Generic;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.SMSRegex.SMSRegex> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.SMSRegex.SMSRegex> Model { get; }
    }
}