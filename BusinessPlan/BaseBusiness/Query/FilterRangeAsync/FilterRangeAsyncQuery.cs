using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusiness.Query.FilterRangeAsync
{
    public class FilterRangeAsyncQuery<TEntity, TDTO, TSearch, TKey> : IQuery<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public FilterRangeAsyncQuery(FilterRangeModel<TSearch> model)
        {
            Model = model;
        }

        public FilterRangeModel<TSearch> Model { get; }
    }
}