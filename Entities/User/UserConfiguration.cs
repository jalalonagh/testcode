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
            builder.Property(p => p.UserName).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.NikName).IsRequired(false);
            builder.Property(p => p.PhoneNumber).IsRequired(true);
            builder.Property(p => p.Email).IsRequired().IsUnicode();
            builder.Property(z => z.IsPerson).HasDefaultValue(false);
            builder.HasOne(u => u.Profile).WithOne(p => p.User).HasForeignKey<Profile.Profile>(p => p.UserId);
            builder.Property(z => z.AccountingUserReferenceId).IsRequired(false);
        }
    }
}