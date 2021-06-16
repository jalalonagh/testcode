﻿using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities.Phone;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Phone.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<PhoneSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<PhoneSearch> Model { get; }
    }
}