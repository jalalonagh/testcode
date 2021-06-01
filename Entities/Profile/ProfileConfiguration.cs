using ManaEnums.Database;
using ManaEnums.Entity.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Profile
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable(nameof(Profile), nameof(SchemaEnum.PROFILE));
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.PhoneNumberId).IsRequired();
            builder.Property(p => p.Points).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.ProfileTypeId).HasDefaultValue((int)ProfileType.END_USER);
            builder.HasOne(p => p.PhoneNumber).WithOne(p => p.Profile).HasForeignKey<Profile>(p => p.PhoneNumberId);
            builder.HasOne(p => p.User).WithOne(u => u.Profile).HasForeignKey<Profile>(p => p.UserId);
            builder.HasMany(p => p.FavoriteProducts).WithOne(f => f.Profile).HasForeignKey(f => f.ProfileId);
            builder.HasIndex(i => i.UserId);
            builder.HasIndex(i => i.ProfileTypeId);
            builder.HasIndex(i => i.PhoneNumberId);

            builder.HasIndex(i => i.UserId);
            builder.HasIndex(i => i.ProfileTypeId);
        }
    }
}