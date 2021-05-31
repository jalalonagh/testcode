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
        public DateTime? CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
