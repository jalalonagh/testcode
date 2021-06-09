using BusinessLayout.Configuration.Commands;
using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.Cart.Command.GetByIdAsync
{
    public class GetByIdAsyncCommand<TEntity, TDTO, TSearch, TKey> : IQuery<ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public GetByIdAsyncCommand(params int[] ids)
        {
            EntityIds = ids;
        }

        public int[] EntityIds { get; }
    }
}