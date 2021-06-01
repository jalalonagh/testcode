using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Profile.PhoneNumberType
{
    internal class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.ToTable(nameof(PhoneNumberType), nameof(SchemaEnum.PROFILE));

            builder.Property(p => p.Description).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.HasMany(p => p.PhoneNumbers).WithOne(p => p.PhoneNumberType).HasForeignKey(p => p.PhoneNumberTypeId);

            builder.HasIndex(i => i.Order);
        }
    }
}