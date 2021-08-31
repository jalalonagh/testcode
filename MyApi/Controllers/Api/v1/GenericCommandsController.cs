//using Common;
//using ManaBaseEntity.Common;
//using ManaDataTransferObject.Common;
//using ManaResourceManager;
//using ManaViewModel.Common;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Services.Models;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WebFramework.Api;

//namespace MyApi.Controllers.Api.v1
//{
//    [ApiVersion("1")]
//    public class GenericCommandsController<TEntity, TVM, TDTO, TKey> : BaseController
//        where TEntity : BaseEntity, new()
//        where TVM : BaseVM<TVM, TEntity, TKey>, new()
//        where TDTO : BaseDTO<TDTO, TEntity, TKey>, new()
//        where TKey : struct
//    {
//        private readonly ILogger<GenericCommandsController<TEntity, TVM, TDTO, TKey>> _logger;
//        private IMediator mediator;
//        ResourceManagerSingleton resource;

//        public GenericCommandsController(ILogger<GenericCommandsController<TEntity, TVM, TDTO, TKey>> logger, IMediator _mediator)
//        {
//            _logger = logger;
//            mediator = _mediator;
//            resource = ResourceManagerSingleton.GetInstance();
//        }

//        [HttpPost("[action]")]
//        public async Task<IApiResult<TVM>> AddAsync(TDTO model, string typeName)
//        {
//            if (string.IsNullOrEmpty(typeName))
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("typenameisrequired").GetMessage());
//            if (!ModelState.IsValid)
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(Activator.CreateInstance(Type.GetType(typeName), model));
//            ServiceResult<TEntity> entity = result.MapTo<ServiceResult<TEntity>>();
//            return entity.ToApiResult<TEntity, TDTO, TVM, TKey>();
//        }
//        [HttpPost("[action]")]
//        public async Task<IApiResult<IEnumerable<TVM>>> AddRangeAsync(IEnumerable<TDTO> models, string typeName)
//        {
//            if (string.IsNullOrEmpty(typeName) || !typeName.Contains("AddAsyncCommand"))
//                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("typenameisrequired").GetMessage());
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(Activator.CreateInstance(Type.GetType(typeName), models));
//            ServiceResult<IEnumerable<TVM>> entities = result.MapTo<ServiceResult<IEnumerable<TVM>>>();
//            return entities.ToApiResult();
//        }
//        [HttpDelete("[action]")]
//        public async Task<IApiResult<TVM>> DeleteAsync(TDTO model, string type)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteAsyncCommand(model));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<IApiResult<TVM>> DeleteByIdAsync(int id)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteByIdAsyncCommand(id));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<IApiResult<IEnumerable<TVM>>> DeleteRangeAsync(IEnumerable<TDTO> models)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteRangeAsyncCommand(models));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpDelete("[action]")]
//        public async Task<IApiResult<IEnumerable<TVM>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new DeleteRangeByIdsAsyncCommand(ids));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<IApiResult<TVM>> UpdateAsync(TDTO model)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateAsyncCommand(model));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<IApiResult<TVM>> UpdateFieldRangeAsync(TDTO model, string fields)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateFieldRangeAsyncCommand(model, fields.Split(",")));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<IApiResult<TVM>> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<TVM>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateFieldRangeByIdAsyncCommand(id, fields));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//        [HttpPut("[action]")]
//        public async Task<IApiResult<IEnumerable<TVM>>> UpdateRangeAsync(IEnumerable<TDTO> models)
//        {
//            if (!ModelState.IsValid)
//                return false.Generate<IEnumerable<TVM>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
//            var result = await mediator.Send(new UpdateRangeAsyncCommand(models));
//            return result.ToApiResult<Entities.Phone.Phone, TDTO, TVM, int>();
//        }
//    }
//}