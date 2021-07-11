using BusinessBaseConfig.Configuration.Queries;
using ManaBaseData.Repositories.Models;
using Services.Models;
using System.Collections.Generic;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.Profile.Profile> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.Profile.Profile> Model { get; }
    }
}