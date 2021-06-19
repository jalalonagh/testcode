using SupplierSystem.Entities.Common;

namespace SupplierSystem.Entities.Supplier.Barecode
{
    public class SupplierBarecodeSearch : BaseSearchEntity
    {
        public string Barecode { get; set; }
        public string QRCode { get; set; }
    }
}
