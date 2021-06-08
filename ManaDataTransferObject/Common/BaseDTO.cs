﻿using Entities;
using ManaAutoMapper.Models;
using System;

namespace ManaDataTransferObject.Common
{
    public class BaseDTO<TDTO, TEntity, TKey> : AutoMapperDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
    }
}