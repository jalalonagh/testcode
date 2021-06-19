using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplierSystem.Entities.Supplier.Store
{
    internal class SupplierStoreConfiguration : IEntityTypeConfiguration<SupplierStore>
    {
        public void Configure(EntityTypeBuilder<SupplierStore> builder)
        {
            builder.ToTable(nameof(SupplierStore), nameof(SchemaEnum.SUPPLIER));

            builder.Property(z => z.SupplierId).IsRequired();
            builder.Property(z => z.StoreCode).IsRequired();
            builder.Property(z => z.DimensionX).IsRequired();
            builder.Property(z => z.DimensionY).IsRequired();
            builder.Property(z => z.DimensionZ).IsRequired();
            builder.Property(z => z.CapacityCBM).IsRequired();
            builder.Property(z => z.MaximumCapacityCBM).IsRequired();

            //builder.HasOne(z => z.CountryName).WithMany(z => z.CountryProvinces).HasForeignKey(z => z.CountryNameId);
        }
    }
}
