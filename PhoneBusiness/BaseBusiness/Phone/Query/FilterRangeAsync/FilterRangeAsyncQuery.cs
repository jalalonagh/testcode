using BusinessBaseConfig.Configuration.Queries;
using Entities.Phone;
using ManaBaseData.Repositories.Models;
using Services.Models;
using System.Collections.Generic;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Query.FilterRangeAsync
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