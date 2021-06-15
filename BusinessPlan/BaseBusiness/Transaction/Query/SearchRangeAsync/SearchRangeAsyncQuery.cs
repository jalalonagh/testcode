using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.Transaction.Transaction> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.Transaction.Transaction> Model { get; }
    }
}