using Common;
using FluentValidation;
using ManaBaseData.Repositories.Models;
using ManaBaseEntity.Common;
using ManaDataTransferObject.Common;
using ManaEntitiesValidation.Extensions;
using ManaResourceManager;
using Services.Base.Contracts;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBusiness
{
    public class Crud<TEntity, TValid, TSearchEntity, TDTO> : ICrud<TEntity, TValid, TSearchEntity, TDTO>, IScopedDependency
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TSearchEntity : BaseSearchEntity, new()
        where TDTO : BaseDTO<TDTO, TEntity, int>, new()
    {
        public IBaseService<TEntity, TSearchEntity> service { get; set; }
        ResourceManagerSingleton resource;
        public Crud(IBaseService<TEntity, TSearchEntity> _service)
        {
            service = _service;
            resource = ResourceManagerSingleton.GetInstance();
        }

        public async Task<IServiceResult<TEntity>> AddAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.AddAsync(entity);
        }
        public async Task<IServiceResult<TEntity>> DeleteAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.DeleteAsync(entity);
        }
        public async Task<IServiceResult<TEntity>> DeleteByIdAsync(int id)
        {
            if (id <= 0)
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.DeleteByIdAsync(id);
        }
        public async Task<IServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            if (ids == null || !ids.Any())
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.GetByIdAsync(ids);
        }
        public async Task<IServiceResult<TEntity>> UpdateAsync(TEntity entity, TValid validator)
        {
            if (!entity.Validate(validator))
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.UpdateAsync(entity);
        }
        public async Task<IServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, TValid validator, params string[] fields)
        {
            if (!entity.Validate(validator) || fields == null || !fields.Any())
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.UpdateFieldRangeAsync(entity, fields);
        }
        public async Task<IServiceResult<TEntity>> UpdateFieldRangeByIdAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            if (Id <= 0 || fields == null || !fields.Any())
                return false.GenerateResult<TEntity>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.UpdateFieldRangeByIdAsync(Id, fields);
        }
    }
}
