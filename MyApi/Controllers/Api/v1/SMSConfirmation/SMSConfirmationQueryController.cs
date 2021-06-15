using BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.FilterRangeAsync;
using BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.GetAllAsync;
using BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.GetByIdAsync;
using BusinessLayout.BaseBusinessLevel.SMSConfirmation.Query.SearchRangeAsync;
using Data.Repositories.Models;
using Entities.SMSConfirmation;
using ManaDataTransferObject.SMSConfirmation;
using ManaViewModel.SMSConfirmation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSConfirmationQueryController : BaseController
    {
        private readonly ILogger<SMSConfirmationQueryController> _logger;
        private IMediator mediator;

        public SMSConfirmationQueryController(ILogger<SMSConfirmationQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> FilterRangeAsync(FilterRangeModel<SMSConfirmationSearch> model)
        {
            var result = await mediator.Send(new FilterRangeAsyncQuery(model));
            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
        }
        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await mediator.Send(new GetAllAsyncQuery(total, more));
            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> SearchRangeAsync(SearchRangeModel<Entities.SMSConfirmation.SMSConfirmation> model)
        {
            var result = await mediator.Send(new SearchRangeAsyncQuery(model));
            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<SMSConfirmationVM>> GetByIdAsync(int[] ids)
        {
            var result = await mediator.Send(new GetByIdAsyncQuery(ids));
            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
        }
    }
}