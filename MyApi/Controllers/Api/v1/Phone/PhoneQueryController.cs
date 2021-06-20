using Data.Repositories.Models;
using Entities.Phone;
using ManaDataTransferObject.Phone;
using ManaViewModel.Phone;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBusiness.BaseBusinessLevel.Phone.Query.FilterRangeAsync;
using PhoneBusiness.BaseBusinessLevel.Phone.Query.GetAllAsync;
using PhoneBusiness.BaseBusinessLevel.Phone.Query.GetByIdAsync;
using PhoneBusiness.BaseBusinessLevel.Phone.Query.SearchRangeAsync;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneQueryController : BaseController
    {
        private readonly ILogger<PhoneQueryController> _logger;
        private IMediator mediator;

        public PhoneQueryController(ILogger<PhoneQueryController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> FilterRangeAsync(FilterRangeModel<PhoneSearch> model)
        {
            var result = await mediator.Send(new FilterRangeAsyncQuery(model));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpGet("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await mediator.Send(new PhoneGetAllAsyncQuery(total, more));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<IEnumerable<PhoneVM>>> SearchRangeAsync(SearchRangeModel<Entities.Phone.Phone> model)
        {
            var result = await mediator.Send(new SearchRangeAsyncQuery(model));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<PhoneVM>> GetByIdAsync(int[] ids)
        {
            var result = await mediator.Send(new GetByIdAsyncQuery(ids));
            return result.ToApiResult<Entities.Phone.Phone, PhoneDTO, PhoneVM, int>();
        }
    }
}