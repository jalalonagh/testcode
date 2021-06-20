using BusinessBaseConfig.Configuration.Queries;
using Data.Repositories.Models;
using Entities.Profile;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        public FilterRangeAsyncQuery(FilterRangeModel<ProfileSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<ProfileSearch> Model { get; }
    }
}