using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.User
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(z => z.Id).ValueGeneratedNever();
            builder.Property(p => p.UserName).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired(true);
            builder.Property(p => p.Email).IsRequired().IsUnicode();

            builder.HasIndex(i => i.UserType);
            builder.HasIndex(i => i.Order);
        }
    }
}