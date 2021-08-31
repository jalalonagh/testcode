using Common;
using Entities.Phone;
using ManaBaseData.Repositories.Models;
using ManaEntitiesValidation.Phone;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.PhoneService
{
    public class PhoneCrud : IPhoneCrud, IScopedDependency
    {
        public IBaseService<Phone, PhoneSearch> service { get; set; }

        public PhoneCrud(IBaseService<Phone, PhoneSearch> _service)
        {
            this.service = _service;
        }

        public async Task<IServiceResult<Phone>> AddAsync(Phone entity)
        {
            PhoneValidator validator = new PhoneValidator();
            var validate = validator.Validate(entity);
            if(!validate.IsValid)
                return false.GenerateResult<Phone>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource)
            return await service.AddAsync(entity);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> AddRangeAsync(IEnumerable<Phone> entities)
        {
            return await service.AddRangeAsync(entities);
        }
        public async Task<IServiceResult<Phone>> DeleteAsync(Phone entity)
        {
            return await service.DeleteAsync(entity);
        }
        public async Task<IServiceResult<Phone>> DeleteByIdAsync(int id)
        {
            return await service.DeleteByIdAsync(id);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> DeleteRangeAsync(IEnumerable<Phone> entities)
        {
            return await service.DeleteRangeAsync(entities);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            return await service.DeleteRangeByIdsAsync(ids);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> FilterRangeAsync(FilterRangeModel<PhoneSearch> filter)
        {
            return await service.FilterRangeAsync(filter);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            return await service.GetAllAsync(total, more);
        }
        public async Task<IServiceResult<Phone>> GetByIdAsync(params object[] ids)
        {
            return await service.GetByIdAsync(ids);
        }
        public async Task<IServiceResult<Phone>> ItemSync(Phone Target, Phone Origin)
        {
            return await service.ItemSync(Target, Origin);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> SearchRangeAsync(SearchRangeModel<Phone> search)
        {
            return await service.SearchRangeAsync(search);
        }
        public async Task<IServiceResult<Phone>> UpdateAsync(Phone entity)
        {
            return await service.UpdateAsync(entity);
        }
        public async Task<IServiceResult<Phone>> UpdateFieldRangeAsync(Phone entity, params string[] fields)
        {
            return await service.UpdateFieldRangeAsync(entity, fields);
        }
        public async Task<IServiceResult<Phone>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            return await service.UpdateFieldRangeByIdAsync(Id, fields);
        }
        public async Task<IServiceResult<IEnumerable<Phone>>> UpdateRangeAsync(IEnumerable<Phone> entities)
        {
            return await service.UpdateRangeAsync(entities);
        }
    }
}
