﻿using BusinessBaseConfig.Configuration.Queries;
using Entities.SMSConfirmation;
using Services.Models;
using System.Collections.Generic;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<SMSConfirmationSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<SMSConfirmationSearch> Model { get; }
    }
}