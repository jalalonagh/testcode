﻿using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.SMSRegex.SMSRegex> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.SMSRegex.SMSRegex> Model { get; }
    }
}