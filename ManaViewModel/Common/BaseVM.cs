using Entities;
using ManaAutoMapper.Models;
using System;

namespace ManaViewModel.Common
{
    public class BaseVM<TDTO, TEntity, TKey> : AutoMapperDTO<TDTO, TEntity, TKey>
        where TDTO : class
        where TEntity : BaseEntity
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