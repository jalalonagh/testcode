using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Profile.PhoneNumberType
{
    internal class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.ToTable(nameof(PhoneNumberType), nameof(SchemaEnum.PROFILE));

            builder.Property(p => p.Description).IsRequired();
            builder.HasMany(p => p.PhoneNumbers).WithOne(p => p.PhoneNumberType).HasForeignKey(p => p.PhoneNumberTypeId);

            builder.HasIndex(i => i.Order);
        }
    }
}