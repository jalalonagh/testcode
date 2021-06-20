using BusinessBaseConfig.Configuration.Queries;
using Services.Models;

namespace ProfileBusiness.BaseBusinessLevel.Profile.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.Profile.Profile>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}