using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities.User;
using Services;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.User.Query.FilterRangeAsync
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