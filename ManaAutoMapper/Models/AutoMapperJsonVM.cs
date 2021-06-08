﻿using Entities;
using Entities.Common;
using System;

namespace ManaAutoMapper.Models
{
    public class AutoMapperJsonVM<TDto, TEntity, TKey>: JsonVM<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {

    }
}