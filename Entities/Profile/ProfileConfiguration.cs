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
            builder.Property(p => p.FirstName).IsRequired(false).HasMaxLength(30);
            builder.Property(p => p.LastName).IsRequired(false).HasMaxLength(30);
            builder.Property(p => p.PhoneNumberId).IsRequired();
            builder.Property(p => p.NationalCode).IsRequired(false).HasMaxLength(25);
            builder.Property(p => p.TelePhoneNumber).IsRequired(false).HasMaxLength(25);
            builder.Property(p => p.EmailAddress).IsRequired(false).HasMaxLength(35);
            builder.Property(p => p.YearBirthDate).IsRequired(false);
            builder.Property(p => p.MonthBirthDate).IsRequired(false);
            builder.Property(p => p.DayBirthDate).IsRequired(false);
            builder.Property(p => p.ImageAddress).IsRequired(false).HasMaxLength(100);
            builder.Property(p => p.Points).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.ProfileTypeId).IsRequired(false).HasDefaultValue((int)ProfileType.END_USER);
            builder.Property(x => x.ExtensionNumber).HasMaxLength(50).IsRequired(false);

            builder.HasOne(p => p.PhoneNumber).WithOne(p => p.Profile).HasForeignKey<Profile>(p => p.PhoneNumberId);
            builder.HasOne(p => p.User).WithOne(u => u.Profile).HasForeignKey<Profile>(p => p.UserId);

            builder.HasMany(p => p.FavoriteProducts).WithOne(f => f.Profile).HasForeignKey(f => f.ProfileId);

            builder.HasIndex(i => i.UserId);
            builder.HasIndex(i => i.ProfileTypeId);
            builder.HasIndex(i => i.PhoneNumberId);
        }
    }
}