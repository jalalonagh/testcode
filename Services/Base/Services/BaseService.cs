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

        public async Task<ServiceResult<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            return await repository.AddAsync(entity, cancellationToken, saveNow);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            var result = await repository.AddRangeAsync(entities, cancellationToken, saveNow);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            return await repository.DeleteAsync(entity, cancellationToken, saveNow);
        }

        public async Task<ServiceResult<TEntity>> DeleteByIdAsync(int id, CancellationToken cancellationToken, bool saveNow = true)
        {
            return await repository.DeleteByIdAsync(id, cancellationToken, saveNow);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            var result = await repository.DeleteRangeAsync(entities, cancellationToken, saveNow);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken, bool saveNow = true)
        {
            var result = await repository.DeleteRangeByIdsAsync(ids, cancellationToken, saveNow);

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

        public async Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken, int total = 0, int more = int.MaxValue)
        {
            var result = await repository.GetAllAsync(cancellationToken, total, more);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }

        public async Task<ServiceResult<TEntity>> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return await repository.GetByIdAsync(cancellationToken, ids);
        }

        public async Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, CancellationToken cancel)
        {
            return await ItemSync(Target, Origin, cancel);
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

        public async Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            return await repository.UpdateAsync(entity, cancellationToken, saveNow);
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(CancellationToken cancellation, TEntity entity, params string[] fields)
        {
            return await repository.UpdateFieldRangeAsync(cancellation, entity, fields);
        }

        public async Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(CancellationToken cancellation, int Id, params KeyValuePair<string, dynamic>[] fields)
        {
            return await repository.UpdateFieldRangeAsync(cancellation, Id, fields);
        }

        public async Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            var result = await repository.UpdateRangeAsync(entities, cancellationToken, saveNow);

            if (result != null && result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(true, ManaEnums.Api.ApiResultStatus.SUCCESS, result, "");

            if (result != null && !result.Any())
                return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.NOT_FOUND, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<TEntity>>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, "مشکلی در سرور رخ داده است");
        }
    }
}
