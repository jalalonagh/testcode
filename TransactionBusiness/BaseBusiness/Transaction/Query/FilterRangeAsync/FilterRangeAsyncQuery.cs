using BusinessBaseConfig.Configuration.Queries;
using Entities.Transaction;
using ManaBaseData.Repositories.Models;
using Services.Models;
using System.Collections.Generic;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Query.FilterRangeAsync
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