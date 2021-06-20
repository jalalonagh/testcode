using ManaBaseEntity.Common;

namespace SupplierSystem.Entities.Barecode
{
    public class Barcode : BaseEntity
    {
        public int? VendorId { get; set; }
        public string Code { get; set; }
        public bool Used { get; set; }
    }
}
