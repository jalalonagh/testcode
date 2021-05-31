using Entities;
using ManaAutoMapper.Models;
using System;

namespace ManaDataTransferObject.Common
{
    public abstract class BaseInterfaceDTO<TDTO, TEntity, TKey> : AutoMapperInterfaceDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
        public DateTime CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}