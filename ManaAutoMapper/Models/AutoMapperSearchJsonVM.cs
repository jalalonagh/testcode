using Entities;
using Entities.Common;
using System;

namespace ManaAutoMapper.Models
{
    public class AutoMapperSearchJsonVM<TDto, TEntity, TKey>: JsonVM<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {

    }
}
