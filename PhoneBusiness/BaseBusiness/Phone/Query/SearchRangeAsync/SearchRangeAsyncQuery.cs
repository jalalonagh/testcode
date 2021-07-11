using BusinessBaseConfig.Configuration.Queries;
using ManaBaseData.Repositories.Models;
using Services.Models;
using System.Collections.Generic;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.Phone.Phone> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.Phone.Phone> Model { get; }
    }
}