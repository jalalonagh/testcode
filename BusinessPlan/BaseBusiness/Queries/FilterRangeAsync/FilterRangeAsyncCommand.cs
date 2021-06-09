using BusinessLayout.Configuration.Commands;
using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.Cart.Command.FilterRangeAsync
{
    public class FilterRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> : IQuery<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public FilterRangeAsyncCommand(FilterRangeModel<TSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<TSearch> Model { get; }
    }
}