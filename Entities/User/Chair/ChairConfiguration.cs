using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.User.Chair
{
    public class ChairConfiguration : IEntityTypeConfiguration<Chair>
    {
        public void Configure(EntityTypeBuilder<Chair> builder)
        {
            builder.ToTable(nameof(Chair));
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.HasMany(x => x.ChairToUsers).WithOne(z => z.Chair).HasForeignKey(z => z.ChairId);
        }
    }
}
