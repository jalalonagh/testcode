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
    
    public partial class TrsAcc
    {
        public int AccLM_Si { get; set; }
        public int AccLT_Si { get; set; }
        public int AccLC_Si { get; set; }
        public int AccLP_Si { get; set; }
        public decimal TrsAcc_Debit_Min { get; set; }
        public decimal TrsAcc_Debit_Max { get; set; }
        public decimal TrsAcc_Credit_Min { get; set; }
        public decimal TrsAcc_Credit_Max { get; set; }
    
        public virtual CtbAccM CtbAccM { get; set; }
        public virtual CtbAccT CtbAccT { get; set; }
        public virtual CtbCost CtbCost { get; set; }
        public virtual CtbProject CtbProject { get; set; }
    }
}
