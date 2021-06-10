using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.SearchRangeAsync
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