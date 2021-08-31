using ManaDataTransferObject.SMS;
using ManaResourceManager;
using ManaViewModel.SMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMSBusiness.BaseBusinessLevel.SMS.Command.AddAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.AddRangeAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.DeleteAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.DeleteByIdAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.DeleteRangeAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.DeleteRangeByIdsAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateFieldRangeAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateFieldRangeByIdAsync;
using SMSBusiness.BaseBusinessLevel.SMS.Command.UpdateRangeAsync;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class SMSCommandsController : BaseController
    {
        private readonly ILogger<SMSCommandsController> _logger;
        private IMediator mediator;
        ResourceManagerSingleton resource;

        public SMSCommandsController(ILogger<SMSCommandsController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
            resource = ResourceManagerSingleton.GetInstance();
        }

        [HttpPost("[action]")]
        public async Task<IApiResult<SMSVM>> AddAsync(SMSDTO model)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddAsyncCommand(model));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPost("[action]")]
        public async Task<IApiResult<IEnumerable<SMSVM>>> AddRangeAsync(IEnumerable<SMSDTO> models)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new AddRangeAsyncCommand(models));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<SMSVM>> DeleteAsync(SMSDTO model)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteAsyncCommand(model));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<SMSVM>> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteByIdAsyncCommand(id));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<IEnumerable<SMSVM>>> DeleteRangeAsync(IEnumerable<SMSDTO> models)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeAsyncCommand(models));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpDelete("[action]")]
        public async Task<IApiResult<IEnumerable<SMSVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand(ids));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<SMSVM>> UpdateAsync(SMSDTO model)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateAsyncCommand(model));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<SMSVM>> UpdateFieldRangeAsync(SMSDTO model, string fields)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand(model, fields.Split(",")));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<SMSVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        {
            if (!ModelState.IsValid)
                return false.Generate<SMSVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand(id, fields));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
        [HttpPut("[action]")]
        public async Task<IApiResult<IEnumerable<SMSVM>>> UpdateRangeAsync(IEnumerable<SMSDTO> models)
        {
            if (!ModelState.IsValid)
                return false.Generate<IEnumerable<SMSVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await mediator.Send(new UpdateRangeAsyncCommand(models));
            return result.ToApiResult<Entities.SMS.SMS, SMSDTO, SMSVM, int>();
        }
    }
}