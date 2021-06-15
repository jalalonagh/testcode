using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMS.Query.SearchRangeAsync
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