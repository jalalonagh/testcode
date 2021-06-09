using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.User.SuspendedUser
{
    internal class SuspendedUserConfiguration : IEntityTypeConfiguration<SuspendedUser>
    {
        public void Configure(EntityTypeBuilder<SuspendedUser> builder)
        {
            builder.ToTable(nameof(SuspendedUser), nameof(SchemaEnum.USER));

            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.ValidCode).IsRequired();
        }
    }
}