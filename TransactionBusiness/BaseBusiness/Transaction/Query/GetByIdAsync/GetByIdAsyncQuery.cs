﻿using BusinessBaseConfig.Configuration.Queries;
using Services.Models;

namespace TransactionBusiness.BaseBusinessLevel.Transaction.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.Transaction.Transaction>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}