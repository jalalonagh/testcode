using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Phone
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable(nameof(Phone), nameof(SchemaEnum.SMS));
            builder.Property(p => p.phoneNumber).IsRequired();
            builder.Property(p => p.name).IsRequired();

            builder.HasIndex(i => i.Order);
            builder.HasIndex(i => i.type);
        }
    }
}