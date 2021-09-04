using BaseBusiness;
using BaseBusiness.Models;
using Common;
using Entities.Phone;
using ManaDataTransferObject.Phone;
using ManaEntitiesValidation.Phone;
using ManaResourceManager;
using ManaViewModel.Phone;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneController// : GenericController<Phone, PhoneValidator, PhoneVM, PhoneDTO>
    {
        private ICrud<Phone, PhoneValidator> crud;
        ResourceManagerSingleton resource;

        public PhoneController(ICrud<Phone, PhoneValidator> _crud)// : base(_crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult> AddAsync(PhoneDTO model)
        {
            //if (!ModelState.IsValid)
            //    return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
            var result = await crud.AddAsync(model.MapTo<Phone>(), new PhoneValidator());
            var entity = result.MapTo<BusinessResult<PhoneVM>>();
            return entity.ToApiResult();
        }
        //[HttpDelete("[action]")]
        //public async Task<ApiResult> DeleteAsync(PhoneDTO model, TValid validator)
        //{
        //    if (!ModelState.IsValid)
        //        return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await crud.DeleteAsync(model.MapTo<Phone>(), validator);
        //    var entity = result.MapTo<BusinessResult<PhoneVM>>();
        //    return entity.ToApiResult();
        //}
        //[HttpDelete("[action]")]
        //public async Task<ApiResult> DeleteByIdAsync(int id)
        //{
        //    if (!ModelState.IsValid)
        //        return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await crud.DeleteByIdAsync(id);
        //    var entity = resource.MapTo<BusinessResult<PhoneVM>>();
        //    return entity.ToApiResult();
        //}
        //[HttpPut("[action]")]
        //public async Task<ApiResult> UpdateAsync(PhoneDTO model, TValid validator)
        //{
        //    if (!ModelState.IsValid)
        //        return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await crud.UpdateAsync(model.MapTo<Phone>(), validator);
        //    var entity = result.MapTo<BusinessResult<PhoneVM>>();
        //    return entity.ToApiResult();
        //}
        //[HttpPut("[action]")]
        //public async Task<ApiResult> UpdateFieldRangeAsync(PhoneDTO model, string fields, TValid validator)
        //{
        //    if (!ModelState.IsValid)
        //        return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await crud.UpdateFieldRangeAsync(model.MapTo<Phone>(), validator, fields);
        //    var entity = result.MapTo<BusinessResult<PhoneVM>>();
        //    return entity.ToApiResult();
        //}
        //[HttpPut("[action]")]
        //public async Task<ApiResult> UpdateFieldRangeByIdAsync(int id, KeyValuePair<string, dynamic> fields)
        //{
        //    if (!ModelState.IsValid)
        //        return false.Generate(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("modelnotvalid").GetMessage());
        //    var result = await crud.UpdateFieldRangeByIdAsync(id, fields);
        //    var entity = result.MapTo<BusinessResult<PhoneVM>>();
        //    return entity.ToApiResult();
        //}
        //[HttpPost("[action]")]
        //public async Task<ApiResult> GetByIdAsync(int[] ids)
        //{
        //    var result = await crud.GetByIdAsync(ids);
        //    var entity = result.MapTo<BusinessResult<PhoneVM>>();
        //    return entity.ToApiResult();
        //}
    }
}