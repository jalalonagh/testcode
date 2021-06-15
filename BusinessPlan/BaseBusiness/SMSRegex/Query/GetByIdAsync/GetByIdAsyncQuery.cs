using BusinessLayout.Configuration.Queries;
using Services;

namespace BusinessLayout.BaseBusinessLevel.SMSRegex.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.SMSRegex.SMSRegex>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}