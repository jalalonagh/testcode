using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Profile.FavoriteProduct
{
    internal class FavoriteProductConfiguration : IEntityTypeConfiguration<FavoriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
        {
            builder.ToTable(nameof(FavoriteProduct), nameof(SchemaEnum.PROFILE));
            builder.HasKey(f => new { f.ProductId, f.ProfileId });
            builder.Property(f => f.ProductId).IsRequired();
            //builder.HasOne(f => f.Product).WithMany(p => p.FavoriteProducts).HasForeignKey(f => f.ProductId);
            builder.Property(f => f.ProfileId).IsRequired();
            builder.HasOne(f => f.Profile).WithMany(p => p.FavoriteProducts).HasForeignKey(f => f.ProfileId);
        }
    }
}