using BusinessLayout.Configuration.Queries;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusiness.Query.SearchRangeAsync
{
    public class SearchRangeAsyncQuery<TEntity, TDTO, TSearch, TKey> : IQuery<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public SearchRangeAsyncQuery(SearchRangeModel<TEntity> model)
        {
            Model = model;
        }

        public SearchRangeModel<TEntity> Model { get; }
    }
}