using Entities.SMS;
using ManaDataTransferObject.SMS;
using ManaViewModel.SMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMSBusiness.BaseBusinessLevel.SMS.Query.FilterRangeAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Query.GetAllAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Query.GetByIdAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Query.SearchRangeAsync;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSQueryController : BaseController
    {
        private readonly ILogger<SMSQueryController> _logger;
        private IMediator mediator;

        public SMSQueryController(ILogger<SMSQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<SMSVM>>> FilterRangeAsync(FilterRangeModel<SMSSearch> model)
        {
            var result = await mediator.Send(new FilterRangeAsyncQuery(model));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<SMSVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await mediator.Send(new SMSGetAllAsyncQuery(total, more));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<SMSVM>>> SearchRangeAsync(SearchRangeModel<Entities.SMS.SMS> model)
        {
            var result = await mediator.Send(new SearchRangeAsyncQuery(model));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<SMSVM>> GetByIdAsync(int[] ids)
        {
            var result = await mediator.Send(new GetByIdAsyncQuery(ids));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
    }
}