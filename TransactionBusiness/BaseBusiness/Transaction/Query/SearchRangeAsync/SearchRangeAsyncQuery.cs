using BusinessBaseConfig.Configuration.Queries;
using Data.Repositories.Models;
using Services.Models;
using System.Collections.Generic;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Query.SearchRangeAsync
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