//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssReceiptD
    {
        public int AssReceiptD_Si { get; set; }
        public Nullable<int> AssReceiptH_Si { get; set; }
        public Nullable<int> AssReceiptDService_Si { get; set; }
        public Nullable<int> AssReceiptDSubService_Si { get; set; }
        public Nullable<int> InvUnt_Si { get; set; }
        public Nullable<byte> AssReceiptDService_Typ { get; set; }
        public Nullable<decimal> AssReceiptD_OriginalPrice { get; set; }
        public Nullable<decimal> AssReceiptD_GurantePrice { get; set; }
        public Nullable<decimal> AssReceiptD_TotalPrice { get; set; }
        public Nullable<double> AssReceiptD_Qty { get; set; }
        public string AssReceiptD_Description { get; set; }
        public Nullable<bool> AssReceiptD_Gurante { get; set; }
        public Nullable<int> AssReceiptD_DocNo { get; set; }
        public Nullable<bool> AssReceiptD_Daghi { get; set; }
    
        public virtual AssReceiptH AssReceiptH { get; set; }
    }
}