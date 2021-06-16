using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities.SMSConfirmation;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.FilterRangeAsync
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