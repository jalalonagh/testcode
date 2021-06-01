using Entities;
using ManaAutoMapper.Models;
using System;

namespace ManaDataTransferObject.Common
{
    public abstract class BaseInterfaceDTO<TDTO, TEntity, TKey> : AutoMapperInterfaceDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
    }
}