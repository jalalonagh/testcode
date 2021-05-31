using ManaAutoMapper.Models;
using System;

namespace ManaViewModel.Common
{
    public abstract class BaseJsonVM<TDTO, TEntity, TKey> : JsonDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, new()
        where TKey : struct
    {
    }
}
