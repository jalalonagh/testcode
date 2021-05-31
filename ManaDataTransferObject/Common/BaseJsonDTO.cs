using ManaAutoMapper.Models;
using System;

namespace ManaDataTransferObject.Common
{
    public abstract class BaseJsonDTO<TDTO, TEntity, TKey> : JsonDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, new()
        where TKey : struct
    {
    }
}
