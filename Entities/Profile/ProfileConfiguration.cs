using ManaEnums.Database;
using ManaEnums.Entity.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasOne(p => p.User).WithOne(u => u.Profile).HasForeignKey<Profile>(p => p.UserId);

            builder.HasIndex(i => i.UserId);
            builder.HasIndex(i => i.ProfileTypeId);
        }
    }
}