using ManaAutoMapper.Models;
using System;

namespace ManaViewModel.Common
{
    public abstract class BaseJsonVM<TDTO, TEntity, TKey> : JsonVM<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, new()
        where TKey : struct
    {
    }
}
