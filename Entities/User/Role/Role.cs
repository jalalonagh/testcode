using ManaBaseEntity.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.User.Role
{
    public class Role : IdentityRole<int>, IEntity
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
