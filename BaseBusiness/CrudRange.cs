﻿using Common;
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
    public class CrudRange<TEntity, TValid, TDTO> : ICrudRange<TEntity, TValid, TDTO>, IScopedDependency
        where TEntity : BaseEntity, new()
        where TValid : AbstractValidator<TEntity>, new()
        where TDTO : BaseDTO<TDTO, TEntity, int>, new()
    {
        public IBaseRangeService<TEntity> service { get; set; }
        ResourceManagerSingleton resource;
        public CrudRange(IBaseRangeService<TEntity> _service)
        {
            service = _service;
            resource = ResourceManagerSingleton.GetInstance();
        }

        public async Task<IServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.AddRangeAsync(entities);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.DeleteRangeAsync(entities);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.DeleteRangeByIdsAsync(ids);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            return await service.GetAllAsync(total, more);
        }
        public async Task<IServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, TValid validator)
        {
            if (!entities.Validate(validator))
                return false.GenerateResult<IEnumerable<TEntity>>(ManaEnums.Api.ApiResultStatus.BAD_REQUEST, null, resource.FetchResource("invalidphonedata").GetMessage());
            return await service.UpdateRangeAsync(entities);
        }
    }
}
