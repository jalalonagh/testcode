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
    
    public partial class SalPromotionD
    {
        public int SalPromotionD_Si { get; set; }
        public Nullable<int> SalPromotionH_Si { get; set; }
        public Nullable<int> InvGds_Si { get; set; }
        public double SalPromotionD_Qty { get; set; }
        public decimal SalPromotionD_UntPrc { get; set; }
        public Nullable<int> SalCustGrp_Si { get; set; }
        public Nullable<int> InvUnt_Si { get; set; }
        public Nullable<int> InvGdsTyp_Si { get; set; }
        public Nullable<int> InvUnt_Si_Dest { get; set; }
        public Nullable<int> InvUnt_SiDest { get; set; }
    
        public virtual InvGd InvGd { get; set; }
        public virtual SalPromotionH SalPromotionH { get; set; }
    }
}
