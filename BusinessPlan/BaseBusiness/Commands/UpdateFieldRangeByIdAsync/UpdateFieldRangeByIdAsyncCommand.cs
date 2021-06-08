using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.Cart.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public UpdateFieldRangeByIdAsyncCommand(int id, params KeyValuePair<string, dynamic>[] fields)
        {
            EntityId = id;
            Fields = fields;
        }

        public int EntityId { get; }
        public KeyValuePair<string, dynamic>[] Fields { get; }
    }
}