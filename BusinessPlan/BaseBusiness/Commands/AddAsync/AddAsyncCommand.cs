﻿using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;

namespace BusinessLayout.Cart.Command.AddAsync
{
    public class AddAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<TEntity>>
        where TEntity : BaseEntity
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>
        where TSearch : BaseSearchEntity
        where TKey : struct
    {
        public AddAsyncCommand(TDTO model)
        {
            Model = model;
        }

        public TDTO Model { get; }
    }
}