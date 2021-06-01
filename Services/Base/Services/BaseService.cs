using Data.Repositories;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Base.Services
{
    public class BaseService<TEntity, TSearchEntity> : IBaseService<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        public IRepository<TEntity, TSearchEntity> repository { get; set; }

        public BaseService(IRepository<TEntity, TSearchEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResult<TEntity>> AddAsync(TEntity entity)
        {
            return await repository.AddAsync(entity);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var result = await repository.AddRangeAsync(entities);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity)
        {
            return await repository.DeleteAsync(entity);
        }

        public async Task<ServiceResult<TEntity>> DeleteByIdAsync(int id)
        {
            return await repository.DeleteByIdAsync(id);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            var result = await repository.DeleteRangeAsync(entities);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            var result = await repository.DeleteRangeByIdsAsync(ids);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            var result = await repository.FilterRangeAsync(filter);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await repository.GetAllAsync(total, more);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            return await repository.GetByIdAsync(ids);
        }

        public async Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin)
        {
            return await ItemSync(Target, Origin);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            var result = await repository.SearchRangeAsync(search);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
            return await repository.UpdateFieldRangeAsync(entity, fields);
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            return await repository.UpdateFieldRangeAsync(Id, fields);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var result = await repository.UpdateRangeAsync(entities);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
    }
}
