using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplierSystem.Entities.Supplier.Request
{
    internal class SupplierSupplyRequestsConfiguration : IEntityTypeConfiguration<SupplierSupplyRequest>
    {
        public void Configure(EntityTypeBuilder<SupplierSupplyRequest> builder)
        {
            builder.ToTable(nameof(SupplierSupplyRequest), nameof(SchemaEnum.SUPPLIER));

            builder.Property(z => z.RequestCode).IsRequired();
            builder.Property(z => z.StoreId).IsRequired();
            builder.Property(z => z.Status).IsRequired();
        }
    }
}
