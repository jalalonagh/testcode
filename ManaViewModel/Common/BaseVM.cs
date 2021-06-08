using Entities;
using ManaAutoMapper;
using ManaAutoMapper.Models;
using System;

namespace ManaViewModel.Common
{
    public class BaseVM<TDTO, TEntity, TKey> : AutoMapperDTO<TDTO, TEntity, TKey>
        where TDTO : class
        where TEntity : BaseEntity
        where TKey : struct
    {
    }
}