using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.SMSConfirmation.SMSConfirmation>>>
    {
        public SearchRangeAsyncQuery(SearchRangeModel<Entities.SMSConfirmation.SMSConfirmation> model)
        {
            Model = model;
        }

        public SearchRangeModel<Entities.SMSConfirmation.SMSConfirmation> Model { get; }
    }
}