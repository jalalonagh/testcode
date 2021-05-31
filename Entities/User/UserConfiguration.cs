using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.User
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(z => z.Id).ValueGeneratedNever();
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NikName).IsRequired(false).HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).IsRequired(true).HasMaxLength(20);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(z => z.IsPerson).HasDefaultValue(false);
            builder.HasOne(u => u.Profile).WithOne(p => p.User).HasForeignKey<Profile.Profile>(p => p.UserId);
            builder.Property(z => z.AccountingUserReferenceId).IsRequired(false);
        }
    }
}