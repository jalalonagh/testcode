using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplierSystem.Entities.Supplier.Barecode
{
    internal class SupplierBarecodeConfiguration : IEntityTypeConfiguration<SupplierBarecode>
    {
        public void Configure(EntityTypeBuilder<SupplierBarecode> builder)
        {
            builder.ToTable(nameof(SupplierBarecode), nameof(SchemaEnum.SUPPLIER));

            builder.Property(z => z.StoreId).IsRequired();
            builder.Property(z => z.Used).IsRequired();
            builder.Property(z => z.Used).HasDefaultValue(false);
            builder.Property(z => z.QRCode).IsRequired();

            builder.HasOne(z => z.Store).WithMany(z => z.Barcodes).HasForeignKey(z => z.StoreId);
        }
    }

}
