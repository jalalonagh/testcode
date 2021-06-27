using BusinessBaseConfig.Configuration.Queries;
using Entities.User;
using Services.Models;
using System.Collections.Generic;

namespace UserBusiness.BaseBusinessLevel.User.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.User.User>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<UserSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<UserSearch> Model { get; }
    }
}