using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusiness.Command.UpdateRangeAsync
{
    public class UpdateRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public UpdateRangeAsyncCommand(IEnumerable<TDTO> model)
        {
            Model = model;
        }

        public IEnumerable<TDTO> Model { get; }
    }
}