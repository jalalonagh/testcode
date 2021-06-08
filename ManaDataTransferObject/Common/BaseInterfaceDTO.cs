using Entities;
using ManaAutoMapper.Models;
using System;

namespace ManaDataTransferObject.Common
{
    public class BaseInterfaceDTO<TDTO, TEntity, TKey> : AutoMapperInterfaceDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
    }
}