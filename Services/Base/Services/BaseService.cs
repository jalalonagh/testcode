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
            var result = await repository.AddAsync(entity);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var result = await repository.AddRangeAsync(entities);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity)
        {
            var result = await repository.DeleteAsync(entity);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> DeleteByIdAsync(int id)
        {
            var result = await repository.DeleteByIdAsync(id);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            var result = await repository.DeleteRangeAsync(entities);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            var result = await repository.DeleteRangeByIdsAsync(ids);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(FilterRangeModel<TSearchEntity> filter)
        {
            var result = await repository.FilterRangeAsync(filter);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(int total = 0, int more = int.MaxValue)
        {
            var result = await repository.GetAllAsync(total, more);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> GetByIdAsync(params object[] ids)
        {
            var result = await repository.GetByIdAsync(ids);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin)
        {
            return await ItemSync(Target, Origin);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(SearchRangeModel<TEntity> search)
        {
            var result = await repository.SearchRangeAsync(search);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity)
        {
            var result = await repository.UpdateAsync(entity);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(TEntity entity, params string[] fields)
        {
            var result = await repository.UpdateFieldRangeAsync(entity, fields);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            var result = await repository.UpdateFieldRangeAsync(Id, fields);

            return result.ToServiceResult();
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var result = await repository.UpdateRangeAsync(entities);

            if (result.IsSuccess && result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result.Data, "");

            if (result.IsSuccess && !result.Data.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
    }
}
