using Entities;
using ManaAutoMapper.Models;
using System;

namespace ManaViewModel.Common
{
    public abstract class BaseInterfaceVM<TDTO, TEntity, TKey> : AutoMapperInterfaceDTO<TDTO, TEntity, TKey>
        where TDTO : class
        where TEntity : class, IEntity
        where TKey : struct
    {
    }
}