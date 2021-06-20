using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManaBaseEntity.Common
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        [Column(Order = 0)]
        public int Order { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}