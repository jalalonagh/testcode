﻿using BusinessLayout.Configuration.Queries;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMS.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.SMS.SMS>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}