using BusinessBaseConfig.Configuration.Queries;
using Services.Models;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Query.GetByIdAsync
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