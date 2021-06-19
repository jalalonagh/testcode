using SupplierSystem.Entities.Common;

namespace SupplierSystem.Entities.Supplier.Request
{
    public class SupplierSupplyRequestSearch : BaseSearchEntity
    {
        public string RequestCode { get; set; }
        public string Status { get; set; }
    }
}
