using BusinessLayout.Configuration.Commands;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.Cart.Command.FilterRangeAsync
{
    public class FilterRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        public FilterRangeAsyncCommand(FilterRangeModel<TSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<TSearch> Model { get; }
    }
}