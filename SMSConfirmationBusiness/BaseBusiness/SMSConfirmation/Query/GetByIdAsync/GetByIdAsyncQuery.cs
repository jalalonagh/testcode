using BusinessBaseConfig.Configuration.Queries;
using Services.Models;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Query.GetByIdAsync
{
    public class GetByIdAsyncQuery : IQuery<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        public GetByIdAsyncQuery(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}