﻿using ManaEnums.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.User
{
    public class User : IdentityUser<int>, IEntity
    {
        public string UserType { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public UserGenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public int? SalcustSi { get; set; }
        public string SalcustCu { get; set; }
        public string SalcustTp { get; set; }
        public string Avatar { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string NikName { get; set; }
        public string ValidCode { get; set; }
        public DateTime ValidCodeExpired { get; set; }
        public bool IsPerson { get; set; }
        public Profile.Profile Profile { get; set; }
        public IEnumerable<ChairToUser.ChairToUser> Chairs { get; set; }
        public int? AccountingUserReferenceId { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}