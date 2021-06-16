using BusinessLayout.Configuration.Queries;
using Services;
using Services.Models;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.GetByIdAsync
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