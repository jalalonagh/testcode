using BusinessLayout.Configuration.Commands;
using Data.Repositories.Models;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.Cart.Command.SearchRangeAsync
{
    public class SearchRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        public SearchRangeAsyncCommand(SearchRangeModel<TEntity> model)
        {
            Model = model;
        }

        public SearchRangeModel<TEntity> Model { get; }
    }
}