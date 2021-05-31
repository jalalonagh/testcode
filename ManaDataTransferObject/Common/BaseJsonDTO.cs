using ManaAutoMapper.Models;
using System;

namespace ManaDataTransferObject.Common
{
    public abstract class BaseJsonDTO<TDTO, TEntity> : JsonDTO<TDTO, TEntity>
        where TDTO : class, new()
        where TEntity : class, new()
    {
        public DateTime? CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
