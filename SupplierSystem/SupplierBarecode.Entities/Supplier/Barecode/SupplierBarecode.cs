﻿using ManaBaseEntity.Common;
using SupplierSystem.Entities.Supplier.Store;

namespace SupplierSystem.Entities.Supplier.Barecode
{
    public class SupplierBarecode : BaseEntity
    {
        public int StoreId { get; set; }
        public SupplierStore Store { get; set; }
        public bool Used { get; set; }
        public string Barecode { get; set; }
        public string QRCode { get; set; }
    }
}
