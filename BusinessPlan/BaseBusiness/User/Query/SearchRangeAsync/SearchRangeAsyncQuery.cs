using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.User.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.User.User>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.User.User> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.User.User> Model { get; }
    }
}