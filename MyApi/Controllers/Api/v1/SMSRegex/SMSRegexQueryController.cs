using BusinessLayout.BaseBusinessLevel.SMSRegex.Query.FilterRangeAsync;
using BusinessLayout.BaseBusinessLevel.SMSRegex.Query.GetAllAsync;
using BusinessLayout.BaseBusinessLevel.SMSRegex.Query.GetByIdAsync;
using BusinessLayout.BaseBusinessLevel.SMSRegex.Query.SearchRangeAsync;
using Data.Repositories.Models;
using Entities.SMSRegex;
using ManaDataTransferObject.SMSRegex;
using ManaViewModel.SMSRegex;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSRegexQueryController : BaseController
    {
        private readonly ILogger<SMSRegexQueryController> _logger;
        private IMediator mediator;

        public SMSRegexQueryController(ILogger<SMSRegexQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<SMSRegexVM>>> FilterRangeAsync(FilterRangeModel<SMSRegexSearch> model)
        {
            var result = await mediator.Send(new FilterRangeAsyncQuery(model));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<SMSRegexVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await mediator.Send(new GetAllAsyncQuery(total, more));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<SMSRegexVM>>> SearchRangeAsync(SearchRangeModel<Entities.SMSRegex.SMSRegex> model)
        {
            var result = await mediator.Send(new SearchRangeAsyncQuery(model));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<SMSRegexVM>> GetByIdAsync(int[] ids)
        {
            var result = await mediator.Send(new GetByIdAsyncQuery(ids));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
    }
}