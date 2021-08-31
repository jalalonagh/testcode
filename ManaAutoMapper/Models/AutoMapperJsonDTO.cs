﻿using ManaBaseEntity.Common;

namespace ManaAutoMapper.Models
{
    public class AutoMapperJsonDTO<TDto, TEntity, TKey> : JsonDTO<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {

    }
}
