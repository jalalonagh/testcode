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
    
    public partial class SalInvcOpr
    {
        public int SalInvcOpr_Si { get; set; }
        public int SalInvcH_Si { get; set; }
        public int SalOpr_Si { get; set; }
        public decimal SalInvcOpr_Value { get; set; }
        public decimal SalInvcOpr_CalcValue { get; set; }
        public Nullable<int> AccM_Si { get; set; }
        public Nullable<int> AccT_Si { get; set; }
    
        public virtual CtbAccM CtbAccM { get; set; }
        public virtual CtbAccT CtbAccT { get; set; }
        public virtual SalInvcH SalInvcH { get; set; }
        public virtual SalOpr SalOpr { get; set; }
    }
}