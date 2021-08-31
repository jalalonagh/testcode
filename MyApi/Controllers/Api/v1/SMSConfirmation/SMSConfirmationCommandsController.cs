//using ManaDataTransferObject.SMSConfirmation;
//using ManaResourceManager;
//using ManaViewModel.SMSConfirmation;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WebFramework.Api;

//namespace MyApi.Controllers.Api.v1
//{
//    [ApiVersion("1")]
//    public class SMSConfirmationCommandsController : BaseController
//    {
//        private readonly ILogger<SMSConfirmationCommandsController> _logger;
//        private IMediator mediator;
//        ResourceManagerSingleton resource;

//        public SMSConfirmationCommandsController(ILogger<SMSConfirmationCommandsController> logger, IMediator _mediator)
//        {
//            _logger = logger;
//            mediator = _mediator;
//            resource = ResourceManagerSingleton.GetInstance();
//        }

//        [HttpPost("[action]")]
//        public async Task<ApiResult<SMSConfirmationVM>> AddAsync(SMSConfirmationDTO model)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<SMSConfirmationVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new AddAsyncCommand(model));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpPost("[action]")]
//        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> AddRangeAsync(IEnumerable<SMSConfirmationDTO> models)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<SMSConfirmationVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new AddRangeAsyncCommand(models));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<ApiResult<SMSConfirmationVM>> DeleteAsync(SMSConfirmationDTO model)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<SMSConfirmationVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteAsyncCommand(model));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<ApiResult<SMSConfirmationVM>> DeleteByIdAsync(int id)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<SMSConfirmationVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteByIdAsyncCommand(id));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> DeleteRangeAsync(IEnumerable<SMSConfirmationDTO> models)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<SMSConfirmationVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteRangeAsyncCommand(models));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<SMSConfirmationVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand(ids));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<ApiResult<SMSConfirmationVM>> UpdateAsync(SMSConfirmationDTO model)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<SMSConfirmationVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateAsyncCommand(model));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<ApiResult<SMSConfirmationVM>> UpdateFieldRangeAsync(SMSConfirmationDTO model, string fields)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<SMSConfirmationVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand(model, fields.Split(",")));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<ApiResult<SMSConfirmationVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<SMSConfirmationVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand(id, fields));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<ApiResult<IEnumerable<SMSConfirmationVM>>> UpdateRangeAsync(IEnumerable<SMSConfirmationDTO> models)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<SMSConfirmationVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateRangeAsyncCommand(models));
//            return result.ToApiResult<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO, SMSConfirmationVM, int>();
//        }
//    }
//}