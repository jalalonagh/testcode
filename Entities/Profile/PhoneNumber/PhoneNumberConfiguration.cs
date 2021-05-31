using System.ComponentModel.DataAnnotations;
using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Profile.PhoneNumber
{
    internal class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable(nameof(PhoneNumber), nameof(SchemaEnum.PROFILE));
            builder.Property(p => p.Number).IsRequired().HasMaxLength(20);
            builder.Property(p => p.PhoneNumberTypeId).IsRequired();
            builder.HasOne(p => p.PhoneNumberType).WithMany(p => p.PhoneNumbers).HasForeignKey(p => p.PhoneNumberTypeId);
            builder.HasOne(p => p.Profile).WithOne(p => p.PhoneNumber).HasForeignKey<Profile>(p => p.PhoneNumberId);
        }
    }
}