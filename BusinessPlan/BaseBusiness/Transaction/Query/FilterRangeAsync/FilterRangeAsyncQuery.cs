using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities.Transaction;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Transaction.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Transaction.Transaction>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<TransactionSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<TransactionSearch> Model { get; }
    }
}