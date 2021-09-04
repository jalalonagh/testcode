using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.User.ChairToUser
{
    public class ChairToUserConfiguration : IEntityTypeConfiguration<ChairToUser>
    {
        public void Configure(EntityTypeBuilder<ChairToUser> builder)
        {
            builder.ToTable(nameof(ChairToUser));
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.ChairId).IsRequired();
            builder.Property(p => p.DateDm).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.DateDs).HasDefaultValue(DateTime.Now.ToPersian());
            builder.Property(p => p.DateDs).HasMaxLength(10);
        }
    }
}
