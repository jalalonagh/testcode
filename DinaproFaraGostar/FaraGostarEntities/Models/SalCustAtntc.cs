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
    
    public partial class SalCustAtntc
    {
        public int SalCustAtntc_Si { get; set; }
        public int SalCust_Si { get; set; }
        public string SalCustAtntc_Ds { get; set; }
        public decimal SalCustAtntc_Price { get; set; }
        public byte SalCustAtntc_Typ { get; set; }
        public bool SalCustAtntc_Actv { get; set; }
        public Nullable<int> SalCustAtntc_SaleType { get; set; }
    
        public virtual SalCust SalCust { get; set; }
    }
}