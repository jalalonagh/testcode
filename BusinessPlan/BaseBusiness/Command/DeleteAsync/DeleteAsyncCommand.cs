using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusiness.Command.DeleteAsync
{
    public class DeleteAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public DeleteAsyncCommand(TDTO model)
        {
            Model = model;
        }

        public TDTO Model { get; }
    }
}