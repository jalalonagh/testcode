using ManaDataTransferObject.SMSRegex;
using ManaResourceManager;
using ManaViewModel.SMSRegex;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.AddAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.AddRangeAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteByIdAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteRangeAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteRangeByIdsAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.UpdateAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.UpdateFieldRangeByIdAsync;
using SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.UpdateRangeAsync;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSRegexCommandsController : BaseController
    {
        private readonly ILogger<SMSRegexCommandsController> _logger;
        private IMediator mediator;
        ResourceManagerSingleton resource;

        public SMSRegexCommandsController(ILogger<SMSRegexCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<IApiResult<SMSRegexVM>> AddAsync(SMSRegexDTO model)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSRegexVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddAsyncCommand(model));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<SMSRegexVM>>> AddRangeAsync(IEnumerable<SMSRegexDTO> models)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSRegexVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddRangeAsyncCommand(models));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<SMSRegexVM>> DeleteAsync(SMSRegexDTO model)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSRegexVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteAsyncCommand(model));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<SMSRegexVM>> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSRegexVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteByIdAsyncCommand(id));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<IEnumerable<SMSRegexVM>>> DeleteRangeAsync(IEnumerable<SMSRegexDTO> models)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSRegexVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeAsyncCommand(models));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<IEnumerable<SMSRegexVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSRegexVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand(ids));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<SMSRegexVM>> UpdateAsync(SMSRegexDTO model)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSRegexVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateAsyncCommand(model));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<SMSRegexVM>> UpdateFieldRangeAsync(SMSRegexDTO model, string fields)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSRegexVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand(model, fields.Split(",")));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<SMSRegexVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSRegexVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand(id, fields));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<IEnumerable<SMSRegexVM>>> UpdateRangeAsync(IEnumerable<SMSRegexDTO> models)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSRegexVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateRangeAsyncCommand(models));
            return result.ToApiResult<Entities.SMSRegex.SMSRegex, SMSRegexDTO, SMSRegexVM, int>();
        }
    }
}