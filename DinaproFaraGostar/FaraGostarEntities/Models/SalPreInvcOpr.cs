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
    
    public partial class SalPreInvcOpr
    {
        public int SalPreInvcOpr_Si { get; set; }
        public int SalPreInvcH_Si { get; set; }
        public int SalOpr_Si { get; set; }
        public decimal SalPreInvcOpr_Value { get; set; }
        public decimal SalPreInvcOpr_CalcValue { get; set; }
    
        public virtual SalOpr SalOpr { get; set; }
        public virtual SalPreInvcH SalPreInvcH { get; set; }
    }
}
