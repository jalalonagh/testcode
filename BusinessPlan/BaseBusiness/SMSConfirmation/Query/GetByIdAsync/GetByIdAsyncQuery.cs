﻿using BusinessLayout.Configuration.Queries;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}