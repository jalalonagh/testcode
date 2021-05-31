using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
