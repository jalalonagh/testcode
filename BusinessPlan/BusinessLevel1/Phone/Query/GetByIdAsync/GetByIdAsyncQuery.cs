using BusinessLayout.Configuration.Queries;
using Services;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.Phone.Phone>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}