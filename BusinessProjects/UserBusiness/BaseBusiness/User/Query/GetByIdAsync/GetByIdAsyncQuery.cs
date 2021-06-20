using BusinessBaseConfig.Configuration.Queries;
using Services.Models;

namespace UserBusiness.BaseBusinessLevel.User.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.User.User>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}