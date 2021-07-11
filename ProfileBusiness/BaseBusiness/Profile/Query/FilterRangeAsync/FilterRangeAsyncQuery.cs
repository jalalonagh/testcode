using BusinessBaseConfig.Configuration.Queries;
using Entities.Profile;
using ManaBaseData.Repositories.Models;
using Services.Models;
using System.Collections.Generic;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Query.FilterRangeAsync
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