using BusinessBaseConfig.Configuration.Queries;
using Services.Models;
using System.Collections.Generic;

namespace SMSBusiness.BaseBusinessLevel.SMS.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMS.SMS>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.SMS.SMS> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.SMS.SMS> Model { get; }
    }
}