using Entities;
using Entities.Common;
using System;

namespace ManaAutoMapper.Models
{
    public abstract class AutoMapperJsonDTO<TDto, TEntity, TKey>: JsonDTO<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {

    }
}
