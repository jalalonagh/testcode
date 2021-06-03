﻿using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.Cart.Command.AddRangeAsync
{
    public class AddRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<IEnumerable<TEntity>>>
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        public AddRangeAsyncCommand(IEnumerable<TDTO> model)
        {
            Model = model;
        }

        public IEnumerable<TDTO> Model { get; }
    }
}