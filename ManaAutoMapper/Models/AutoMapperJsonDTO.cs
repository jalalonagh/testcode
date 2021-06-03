using Entities;
using Entities.Common;
using System;

namespace ManaAutoMapper.Models
{
    public class AutoMapperJsonDTO<TDto, TEntity, TKey>: JsonDTO<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : BaseSearchEntity
        where TKey : struct
    {

    }
}
