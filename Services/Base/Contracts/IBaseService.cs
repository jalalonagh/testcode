using Data.Repositories;
using Entities;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IBaseService<TEntity, TSearchEntity>
        where TEntity : class, IEntity
        where TSearchEntity : class, ISearchEntity
    {
        IRepository<TEntity, TSearchEntity> repository { get; }

        Task<ServiceResult<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        Task<ServiceResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task<ServiceResult<TEntity>> DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        Task<ServiceResult<IEnumerable<TEntity>>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task<ServiceResult<TEntity>> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        Task<ServiceResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken, int total = 0, int more = int.MaxValue);
        Task<ServiceResult<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        Task<ServiceResult<IEnumerable<TEntity>>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task<ServiceResult<IEnumerable<TEntity>>> FilterRangeAsync(TSearchEntity entity, CancellationToken cancel, int total = 0, int more = int.MaxValue);
        Task<ServiceResult<IEnumerable<TEntity>>> SearchRangeAsync(TEntity entity, string text, CancellationToken cancel, int total = 0, int more = int.MaxValue);
        Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(CancellationToken cancellation, TEntity entity, params string[] fields);
        Task<ServiceResult<TEntity>> UpdateFieldRangeAsync(CancellationToken cancellation, int Id, params KeyValuePair<string, dynamic>[] fields);
        Task<ServiceResult<TEntity>> ItemSync(TEntity Target, TEntity Origin, CancellationToken cancel);
    }
}
