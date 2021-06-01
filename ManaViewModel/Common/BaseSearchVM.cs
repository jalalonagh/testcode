using Entities.Common;
using ManaAutoMapper.Models;
using System;

namespace ManaViewModel.Common
{
    public abstract class BaseSearchVM<TDTO, TEntity, TKey> : AutoMapperJsonDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {
    }
}
